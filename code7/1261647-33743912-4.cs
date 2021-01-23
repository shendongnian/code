    class GameObject 
    {
        public Action onFrame;
    
        public GameObject (Action of) //constructor
        {
            onFrame = of;
            Thread t = new Thread(runOnFrame);
            t.isBackgroundThread = true;
            t.Start();
        }
    
        protected void runOnFrame () 
        {
            while (true)
            {
                Thread.Sleep(100);
                if (onFrame != null) onFrame();
            }
        }
    }
