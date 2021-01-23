    class TimeLogLineParser
    {
        public TimeLogData ParseLine(string line)
        {
            TimeLogData result = null;
            var tmp = line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (tmp.Length == 7)
            {
                result = new TimeLogData
                {
                    NoMchn = tmp[0],
                    EnNo = Convert.ToInt32(tmp[1]),
                    Name = tmp[2],
                    Mode = Convert.ToInt32(tmp[3]),
                    IOMd = Convert.ToInt32(tmp[4]),
                    Time = Convert.ToDateTime(tmp[5] + " " + tmp[6])
                };
            }
            return result;
        }
    }
