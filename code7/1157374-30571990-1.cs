    [WebMethod]
    public static string Edit(string dt1)
    {
    string pcId = dt1;
    NpgsqlConnection conn = new NpgsqlConnection("Server=192.168.0.133;User Id=123; " + "Password=123;Database=checDB;"); 
    try
     {
       conn.Open(); 
       NpgsqlCommand command = new NpgsqlCommand("select Center_Id,center_Name from tbl_Profit_Centers where Center_Id = " + pcId, conn);
       NpgsqlDataReader dr = command.ExecuteReader();
       conn.Close();
       return dr["center_Name"].ToString();
      }
    catch (Exception ex)
      {
        return "failure";
      }
}
    .ajax({
            type: "POST",
            url: "CS.aspx/Edit", 
            data: "{'dt1':'" + dt1 +"'}",
            contentType: "application/json; charset=utf-8",
            dataType:"json", 
            success: function(result)
             {
                $('input[id$=txtEditValue]').val(result.d);
             }
        });
