        class yourTimer{ 
        public  void startTimer(Action a)
        {
            ParameterizedThreadStart fu = new ParameterizedThreadStart(waiter);
            Thread t1 = new Thread(fu);
            t1.Start(a);
        }
        public void stopTimer()
        private void waiter(object o)
        {
            Action ac = (Action)o;
            while(waitin)
            {
                if(DateTime.Now.Millisecond%10==0)
                {
                    ac.Invoke();
                }
                continue;
            }
        }
      }
