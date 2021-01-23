     protected override void OnStart(string[] args)
        {
            try
            {
                this.StartJobs();
            }
            catch (Exception ex)
            {
                // catching exception
            }
        }
    
        public void StartWork()
        {
           // all the logic here
        }
