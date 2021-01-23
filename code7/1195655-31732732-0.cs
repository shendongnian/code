    int memberID = [some number];
    DataTable results = new DataTable(); //Your SQL row will be "saved" in here
    string command = string.Format("select * from MemberDetails where MemberID = {0}", memberID);
    
    using (SqlDataAdapter sda = new SqlDataAdapter(command, con))
    {
        sda.Fill(results); //Your DataTable now has your values
    }
