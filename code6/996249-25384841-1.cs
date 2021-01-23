    public class Graduate
    {
         public long Id {get;set;}
         public string LastName {get;set;}
         //rest of the fields
    }
    public static Graduate GetInformation(string Username)
    {
    //haven't put all the code here, you have the idea I guess
    //also wrap this around try-catch block
    SqlDataReader sdr = DAT.GetInformation(this.username);
    
    using(sdr)
    {
       if(sdr.HasRows)
       {
           while(sdr.Read())
           {
              var objGard = new Graduate()
                         {
                            ID = sdr["Idno"] != DBNull.Value
                                    ? long.Parse(sdr["Idno"].ToString())
                                    : 0,
                            LastName = reader["Lname"] != DBNull.Value
                                        ? reader["Lname"].ToString()
                                        : ""
                            //rest of the fields
                         };
                   return objGard;             
           }
       }
    }
    return null;
}
    
    public Graduate GetInformation()
    {
        return DAT.GetInformation(this.username);
    }
    var grad = GetInformation();
    if(grad ==null) return;
    
    txtId.Text = grad.Id;
    txtLasName.Text = grad.LastName;
