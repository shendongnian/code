    using System;
    using Android.OS;
    using Android.Util;
    
    namespace MyFileObserver
    {
    	public class MyPathObserver : Android.OS.FileObserver
    	{
    		static FileObserverEvents _Events = (FileObserverEvents.AllEvents);
    		const string tag = "StackoverFlow";
    
    		public MyPathObserver (String rootPath) : base(rootPath, _Events)
    		{
    			Log.Info(tag, String.Format("Watching : {0}", rootPath)); 
    		}
    
    		public MyPathObserver (String rootPath, FileObserverEvents events) : base(rootPath, events)
    		{
    			Log.Info(tag, String.Format("Watching : {0} : {1}", rootPath, events)); 
    		}
    
    		public override void OnEvent(FileObserverEvents e, String path)
    		{
    			Log.Info(tag, String.Format("{0}:{1}",path, e)); 
    		}
    	}
    }
