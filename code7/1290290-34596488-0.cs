    //Declared elsewhere
    public class DataPoint
    {
        public DateTime Time {get; set;}
        public String Message {get; set;}
        public override string ToString()
        {
            var message = this.Message;
            if (String.IsNullOrEmpty(message))
            {
                message = "ReadError";
            }
            return message + "\t" + this.Time.ToString("%d"); 
        }
    }
        List<DataPoint> dataPoints = new List<DataPoint>(pArray.Length); //make the default size the same as pArray so we don't waist time growing the list.
        DateTime utcStartTime = DateTime.UtcNow;
        while (DateTime.UtcNow <= (utcStartTime.AddSeconds(recordTime)))                       //Run the read-write function for approximately the time specified
        {
            try
            {
                Write("Write.Request");                                 //Requests the data
                Pmeas = Read();                                         //Reads the returned string. String = "ReadError" if no result is found.
                var dataPoint = new DataPoint
                    {
                        Time = DateTime.UtcNow,
                        Message = Pmeas
                    };
                dataPoints.Add(dataPoint);                                                     
                Pmeas = "ReadError";                                    //Reset Pmeas to prove in file that Pmeas experienced a read error
            }
            catch (Exception f)                                         //Catch an exception if try fails
            {
                Console.WriteLine("{0} Exception caught.", f);
            }
        }
        //Now that we are out of the time critical section do the slow work of formatting the data.
        foreach(var dataPoint in dataPoints)
        {
            pArray[i] = dataPoint.ToString() + Environment.NewLine;    //Appends the Pmeas of each instance to a string array with a timestamp
            i++;                                            //let i grow so that the array can also grow, plus have a variable already available for being having the string being written into a file (not part of question or code-in-question).
        }
