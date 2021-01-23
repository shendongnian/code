           string queryString = string.Format("*[System[TimeCreated[@SystemTime>='{0}' and @SystemTime<='{1}']]]",
                DateTime.Now.Date.AddDays(-10).ToString("s"),
                DateTime.Now.Date.ToString("s"));
            var q = new EventLogQuery("Microsoft-Windows-User Profile Service/Operational", PathType.LogName, queryString);
            var r = new EventLogReader(q);
            var list = new List<EventRecord>(); 
            EventRecord er = r.ReadEvent();
            while (er != null) {
                list.Add(er);
                er = r.ReadEvent();
            }
