            EventLog myLog = new EventLog();
            myLog.Log = "Security";
            foreach (EventLogEntry entry in myLog.Entries)
            {
                if (entry.InstanceId == 4648 || entry.InstanceId == 4654)
                    Console.WriteLine("\tEntry: " + entry.Message);
            }
            Console.ReadLine(); 
