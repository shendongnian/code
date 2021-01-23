            private static SharpSvn.SvnRevision TimeToPreRevision(DateTime date, Uri link, SharpSvn.SvnClient client)
        {
            SvnRevision retr = new SvnRevision();
            DateTime retr_date = new DateTime();
            SvnLogArgs args = new SvnLogArgs { Start = date};
            client.Log(link, args, delegate (object sender3, SvnLogEventArgs e)
             {
                 if (e.Time.Date < date.Date)
                 {
                     if(retr.Time < e.Time)
                     {
                         retr = e.Revision;
                         retr_date = e.Time;
                     }
                 }
             });
            return retr;
        }
