     public class UserInfo
    {
            public string Name;
            public string Code;
            public string Salary;
    }
    
    
    [WebMethod]
    public List<UserInfo> getTableData()
    {
        SqlDataReader dr;
        List<UserInfo> UserInfo = new List<UserInfo>();
     
        using (SqlConnection con = new SqlConnection(conn))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "ProcedureName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string Name = dr["Name"].ToString();
                        string Code = dr["Code"].ToString();
                        string makingyear = dr["carYear"].ToString();
                         UserInfo.Add(new usr {Name = Name, Code = Code });
                    }
                }
            }
        }
        return UserInfo;
    }
----------
    $("#button").on("click", function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
             data: "{null}",
            url: "WebService.asmx/getTableData",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json", // dataType is json format
            success: OnSuccess,
            error: OnErrorCall
        });
       
        function OnSuccess(response) {
          console.log(response.d)
        }
        function OnErrorCall(response) { console.log(error); }
        });
