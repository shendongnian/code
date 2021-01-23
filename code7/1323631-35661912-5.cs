        static void Main(string[] args)
        {
            try
            {
                ICollection<LivePost> lps = new List<LivePost>();
                lps.Add(new LivePost() { UserName = "LivePostUserName1", PostDescription = "LivePostDescription1" });
                lps.Add(new LivePost() { UserName = "LivePostUserName2", PostDescription = "LivePostDescription2" });
                lps.Add(new LivePost() { UserName = "LivePostUserName3", PostDescription = "LivePostDescription3" });
                lps.Add(new LivePost() { UserName = "LivePostUserName4", PostDescription = "LivePostDescription4" });
                ICollection<LiveStream> lss = new List<LiveStream>();
                lss.Add(new LiveStream() { UserName = "LiveStreamUserName1", Status = "LiveStreamStatus1" });
                lss.Add(new LiveStream() { UserName = "LiveStreamUserName2", Status = "LiveStreamStatus2" });
                //lss.Add(new LiveStream() { UserName = "LiveStreamUserName3", Status = "LiveStreamStatus3" });
                AlternatingThingsViewModel atmv = new AlternatingThingsViewModel(lps, lss);
                int modCheckCount = 0;
                foreach (AbstractThing at in atmv.AbstractThings)
                {
                    Console.WriteLine("{0}, {1}", at.TheUserName, at.TheDescription);
                    if (++modCheckCount % 2 == 0)
                    {
                        Console.WriteLine("");
                    }
                }
