    public class MyType
    {
    	struct Entry
    	{
    		public bool IsSet;
    		public int HandlerCount;
    		public Action[] HandlerList;
    		public void Add(Action handler)
    		{
    			if (HandlerList == null) HandlerList = new Action[4];
    			else if (HandlerList.Length == HandlerCount) Array.Resize(ref HandlerList, 2 * HandlerCount);
    			HandlerList[HandlerCount++] = handler;
    		}
    	}
    	const int N = 10;
    	readonly Entry[] entries = new Entry[N];
    	readonly object syncLock = new object();
    	public void Set(int index)
    	{
    		int handlerCount;
    		Action[] handlerList;
    		lock (syncLock)
    		{
    			if (entries[index].IsSet) throw new InvalidOperationException();
    			entries[index].IsSet = true;
    			handlerCount = entries[index].HandlerCount;
    			handlerList = entries[index].HandlerList;
    		}
    		for (int i = 0; i < handlerCount; i++)
    			handlerList[i]();
    	}
    	public void AddHandler(int index, Action handler)
    	{
    		if (handler == null) throw new ArgumentException("handler");
    		lock (syncLock)
    		{
    			entries[index].Add(handler);
    			if (!entries[index].IsSet) return;
    		}
    		handler();
    	}
    }
