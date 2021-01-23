        private void WaitForNoWorkThenGC()
        {
            // Continue running thread while in use
            while (_running)
            {
                // Wait for some work to be complete
                _workFlag.WaitOne();
                // If there is no work being processed call GC.Collect() 
                if (_workCounter == 0)
                {
                    GC.Collect();
                }
            }
        } 
