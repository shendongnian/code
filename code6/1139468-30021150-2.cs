    public class Result
        {
            public Result()
            { }
            public DateTime aDate { get; set; }
            public String Time { get; set; }
            public int Marker { get; set; }
            public string speed { get; set; }
        }
...
    char pipe = Convert.ToChar("|");
            string[] splits = null;
            List<Result> ResultList = new List<Result>();
            foreach (DataRow row in dsSet.Tables[0].Rows)
            {
                result = new Result();
                splits = row["Running"].Split(pipe);
                result.aDate = Convert.ToDateTime(splits[2]);
                result.Time = String.Format("{0}", splits[3]);
                result.Marker = Convert.ToInt32(splits[4]);
                result.speed = String.Format("{0}", splits[5]);
                ResultList.Add(result);
                
            }
