    public class Result
        {
            public Result()
            { }
            public string aDate { get; set; }
            public string Time { get; set; }
            public string Marker { get; set; }
            public string speed { get; set; }
        }
...
    char pipe = Convert.ToChar("|");
            string[] splits = null;
            List<Result> ResultList = new List<Result>();
            foreach (DataRow row in dsSet.Tables[0].Rows)
            {
                result = new Result();
                splits = String.Format("{0}",row["Running"]).Split(pipe);
                result.aDate = String.Format("{0}", splits[2]);
                result.Time = String.Format("{0}", splits[3]);
                result.Marker = String.Format("{0}", splits[4]);
                result.speed = String.Format("{0}", splits[5]);
                ResultList.Add(result);
                
            }
