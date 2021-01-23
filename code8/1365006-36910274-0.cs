    class Live
    {
        Thread scheduler;
        public Live()
        { 
            scheduler = new Thread(UpdateResults);
            scheduler.Start();
        }
        public void UpdateResults() 
        {
           //do some stuff
        }
    }
