    foreach (Student s in Students){
 
         foreach (LogEntry log in LogFile)
        {
            if (log.Student.equals(s) && log.Type.ToString().Equals("Start"))
            {
                TempList.Add(log);
            }
        }
        for (int i = 0; i < TempList.Count; i++) 
        {
            Console.WriteLine("The difference in time is " + TimeDifference(TempList[i].StartTime, Student1StartTimes[i]) + " minutes." );         
        }
        TempList.Clear(); //Clear the temporary list
    }
