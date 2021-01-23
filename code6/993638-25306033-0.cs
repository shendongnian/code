        static Task _backgroundTask;
        void DoWork(param1, etc)
        {
            if (_backgroundTask != null)
                _backgroundTask = System.Threading.Tasks.Task.Run(() => DoWorkBackground(param1, etc) );
        }
        void DoWorkBackground(param1, etc)
        {
            //long running logic
        }
