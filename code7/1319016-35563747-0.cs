    class PageBuffer : IDisposable
    {
    	public static PageBuffer Open(string path)
    	{
    		return new PageBuffer(File.OpenRead(path));
    	}
    
    	private PageBuffer(Stream stream)
    	{
    		this.stream = stream;
    		Source = Image.FromStream(stream);
    		PageCount = Source.GetFrameCount(FrameDimension.Page);
    		if (PageCount < 2) return;
    		pages = new Image[PageCount];
    		var worker = new Thread(LoadPages) { IsBackground = true };
    		worker.Start();
    	}
    
    	private void LoadPages()
    	{
    		for (int index = 0; ; index++)
    		{
    			lock (syncLock)
    			{
    				if (disposed) return;
    				if (index >= pages.Length)
    				{
    					// If you don't need the source image, 
    					// uncomment the following line to free some resources
    					//DisposeSource();
    					return;
    				}
    				if (pages[index] == null)
    					pages[index] = LoadPage(index);
    			}
    		}
    	}
    
    	private Image LoadPage(int index)
    	{
    		Source.SelectActiveFrame(FrameDimension.Page, index);
    		return new Bitmap(Source);
    	}
    
    	private Stream stream;
    	private Image[] pages;
    	private object syncLock = new object();
    	private bool disposed;
    
    	public Image Source { get; private set; }
    	public int PageCount { get; private set; }
    	public Image GetPage(int index)
    	{
    		if (disposed) throw new ObjectDisposedException(GetType().Name);
    		if (PageCount < 2) return Source;
    		var image = pages[index];
    		if (image == null)
    		{
    			lock (syncLock)
    			{
    				image = pages[index];
    				if (image == null)
    					image = pages[index] = LoadPage(index);
    			}
    		}
    		return image;
    	}
    
    	public void Dispose()
    	{
    		if (disposed) return;
    		lock (syncLock)
    		{
    			disposed = true;
    			if (pages != null)
    			{
    				foreach (var item in pages)
    					if (item != null) item.Dispose();
    				pages = null;
    			}
    			DisposeSource();
    		}
    	}
    
    	private void DisposeSource()
    	{
    		if (Source != null)
    		{
    			Source.Dispose();
    			Source = null;
    		}
    		if (stream != null)
    		{
    			stream.Dispose();
    			stream = null;
    		}
    	}
    }
