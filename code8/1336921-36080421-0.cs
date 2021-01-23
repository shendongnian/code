               DateTime myDate =  DateTime.Parse("3/28/2016 10:40");
                TimeSpan timeToEvent = myDate.Subtract(DateTime.Now);
                string message = string.Format("Days : {0}, Hours : {1}, Minutes : {2}", timeToEvent.Days, timeToEvent.Hours, timeToEvent.Minutes);
                Console.WriteLine(message);
                Console.ReadLine();
