        public void StartThread()
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(this.DoWork);
            Thread th = new Thread(pts);
            int i =5;
            th.Start(i);
        }
        public void DoWork(object data)
        {
            Console.WriteLine("I got data='{0}'", data);
        }
