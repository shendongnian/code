        while(!_stop)
        { 
            if (_mainEvent != null)
                try
                { 
                    _mainEvent(this, new EventArgs());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            Thread.Sleep(_ms);
        }
