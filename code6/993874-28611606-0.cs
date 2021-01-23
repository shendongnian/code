        [WebMethod]
        public static string[] MemberLookup(string MbrFullName)
        {
            DataSet ds = (dataset provider goes here)
            List<string> members = new List<string>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            { members.Add(string.Format("{0}-{1}", dr["label"].ToString(), dr["value"].ToString())); }
            return members.ToArray();
        }
