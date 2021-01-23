        public void SomeFunction() 
        {
            DateTime lastRunTime = DateTime.MinValue;
            foreach(MyEvent changedEvent in changedEvents) 
            {
                lastRunTime = DateTime.Now;
                for (int index = 0; index < 10; index++)
                {
                    if (lastRunTime.Second == DateTime.Now.Second)
                    {
                        service.ChangeEvent(changedEvent);
                    }
                    else
                    {
                        break;//it took longer than 1 sec for 10 calls, so break for next second
                    }
                }
            }
        }
