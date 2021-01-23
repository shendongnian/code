    class YourClass
    {
        public YourClass(PipeStream pipeClient)
        {
            _pipeClient = pipeClient;
            var task = new Task(MessageHandler, TaskCreationOptions.LongRunning);
            task.Start();
        }
        
        //SNIP...
        private void MessageHandler()
        {
            while(_pipeClient.IsConnected)
            {
                IFormatter f = new BinaryFormatter();
                try
                {
                     object temp = f.Deserialize(_pipeClient);
                     result = (Func<T>)temp;
                }
                catch
                {
                    //You really should do some kind of logging.
                }
            }
        }
    }
