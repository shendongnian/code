        public class Member
        {
            public int MemberId {get; set;}
            public string Name {get; set;}
            public string Surname {get; set;}
        }
    
    public IList<Member> GetMembers()
    {
        OleDbConnection conn = null;
        OleDbDataReader reader = null;
        try
        {
            conn = new OleDbConnection(
                "Provider=Microsoft.Jet.OLEDB.4.0; " + 
                "Data Source=" + Server.MapPath("MyDataFolder/MyAccessDb.mdb"));
            conn.Open();
    
            OleDbCommand cmd = 
                new OleDbCommand("Select MemberID, Name, Surname FROM MemberDetails", conn);
    
            reader = cmd.ExecuteReader();
    
            var members = new List<Member>();
            while(reader.Read())
            {
                var member = new Member();
                member.MemberID = reader.GetInt32(reader.GetOrdinal("MemberID"));
                member.Name = reader["Name"].ToString();
                member.Surname = reader["Surname"].ToString();
    
                members.Add(member);
            }
            
            return members;
        }
        finally
        {
            if (reader != null)  reader.Close();
            if (conn != null)  conn.Close();
        }
    
        return null;
    }
