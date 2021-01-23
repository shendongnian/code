    public void sleepAdd(T name)
        {
            #region locking code
            lock (this)
            {
                if (count < max)
                {
                    count++;
                    
                    coffeeBevrages.Add(name);
                    Monitor.PulseAll(this);
                }
                else 
                {
                    while (count == max) 
                    {
                        Console.WriteLine("Producer to Sleep");
                        Monitor.Wait(this);
                    }
                    sleepAdd(name);
                }
            #endregion
            }   
            
        }
        public void sleepremove(T name) 
        {
            lock (this)
            {
                if (count > 0)
                {
                    consumed++;
                    Console.WriteLine(consumed);
                    count--;
                    Monitor.PulseAll(this);
                }
                else
                {
                    while (count == 0) 
                    {
                        Console.WriteLine("Consumer to Sleep");
                        Monitor.Wait(this);
                    }
                    sleepremove(name);
                }
            }
            
        }
