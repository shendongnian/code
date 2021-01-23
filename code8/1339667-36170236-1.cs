        //Input
        StreamReader fileSR = new StreamReader("hours.txt");
        string line = fileSR.ReadLine();
        while (line != null) //check while not EOF
        {
            double hours = 0;
            if (double.TryParse(line, out hours)) // check if line is a valid double
            {
               hoursArray.Add(hours);
            }
            line = fileSR.ReadLine();
        }
        fileSR.Close();
