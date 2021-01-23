    class PageBuffer : IDisposable
    {
    	public const int DefaultCacheSize = 5;
    
    	public static PageBuffer Open(string path, Size maxSize, int cacheSize = DefaultCacheSize)
    	{
    		return new PageBuffer(File.OpenRead(path), maxSize, cacheSize);
    	}
    
    	private PageBuffer(Stream stream, Size maxSize, int cacheSize)
    	{
    		this.stream = stream;
    		source = Image.FromStream(stream);
    		pageCount = source.GetFrameCount(FrameDimension.Page);
    		if (pageCount < 2) return;
    		pageCache = new Image[Math.Min(pageCount, Math.Max(cacheSize, 3))];
    		pageSize = source.Size;
    		if (!maxSize.IsEmpty)
    		{
    			float scale = Math.Min((float)maxSize.Width / pageSize.Width, (float)maxSize.Height / pageSize.Height);
    			pageSize = new Size((int)(pageSize.Width * scale), (int)(pageSize.Height * scale));
    		}
    		var worker = new Thread(LoadPages) { IsBackground = true };
    		worker.Start();
    	}
    
    	private void LoadPages()
    	{
    		while (true)
    		{
    			lock (syncLock)
    			{
    				if (disposed) return;
    				int index = Array.FindIndex(pageCache, 0, pageCacheSize, p => p == null);
    				if (index < 0)
    					Monitor.Wait(syncLock);
    				else
    					pageCache[index] = LoadPage(pageCacheStart + index);
    			}
    		}
    	}
    
    	private Image LoadPage(int index)
    	{
    		source.SelectActiveFrame(FrameDimension.Page, index);
    		return new Bitmap(source, pageSize);
    	}
    
    	private Stream stream;
    	private Image source;
    	private int pageCount;
    	private Image[] pageCache;
    	private int pageCacheStart, pageCacheSize;
    	private object syncLock = new object();
    	private bool disposed;
    	private Size pageSize;
    
    	public Image Source { get { return source; } }
    	public int PageCount { get { return pageCount; } }
    	public Image GetPage(int index)
    	{
    		if (disposed) throw new ObjectDisposedException(GetType().Name);
    		if (PageCount < 2) return Source;
    		lock (syncLock)
    		{
    			AdjustPageCache(index);
    			int cacheIndex = index - pageCacheStart;
    			var image = pageCache[cacheIndex];
    			if (image == null)
    				image = pageCache[cacheIndex] = LoadPage(index);
    			return image;
    		}
    	}
    
    	private void AdjustPageCache(int pageIndex)
    	{
    		int start, end;
    		if ((start = pageIndex - pageCache.Length / 2) <= 0)
    			end = (start = 0) + pageCache.Length;
    		else if ((end = start + pageCache.Length) >= PageCount)
    			start = (end = PageCount) - pageCache.Length;
    		if (start < pageCacheStart)
    		{
    			int shift = pageCacheStart - start;
    			if (shift >= pageCacheSize)
    				ClearPageCache(0, pageCacheSize);
    			else
    			{
    				ClearPageCache(pageCacheSize - shift, pageCacheSize);
    				for (int j = pageCacheSize - 1, i = j - shift; i >= 0; j--, i--)
    					Exchange(ref pageCache[i], ref pageCache[j]);
    			}
    		}
    		else if (start > pageCacheStart)
    		{
    			int shift = start - pageCacheStart;
    			if (shift >= pageCacheSize)
    				ClearPageCache(0, pageCacheSize);
    			else
    			{
    				ClearPageCache(0, shift);
    				for (int j = 0, i = shift; i < pageCacheSize; j++, i++)
    					Exchange(ref pageCache[i], ref pageCache[j]);
    			}
    		}
    		if (pageCacheStart != start || pageCacheStart + pageCacheSize != end)
    		{
    			pageCacheStart = start;
    			pageCacheSize = end - start;
    			Monitor.Pulse(syncLock);
    		}
    	}
    
    	void ClearPageCache(int start, int end)
    	{
    		for (int i = start; i < end; i++)
    			Dispose(ref pageCache[i]);
    	}
    
    	static void Dispose<T>(ref T target) where T : class, IDisposable
    	{
    		var value = target;
    		if (value != null) value.Dispose();
    		target = null;
    	}
    
    	static void Exchange<T>(ref T a, ref T b) { var c = a; a = b; b = c; }
    
    	public void Dispose()
    	{
    		if (disposed) return;
    		lock (syncLock)
    		{
    			disposed = true;
    			if (pageCache != null)
    			{
    				ClearPageCache(0, pageCacheSize);
    				pageCache = null;
    			}
    			Dispose(ref source);
    			Dispose(ref stream);
    			if (pageCount > 2)
    				Monitor.Pulse(syncLock);
    		}
    	}
    }
