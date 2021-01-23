    DateTime start()
        { 
            DateTime d = new DateTime();
            return d.AddMilliseconds(Environment.TickCount);
        }
