    public Boolean InsertPersonalInfo(string NIC, string Name, string FatherHusbandName, DateTime DOB, bool Gender, string Religion, string Domicile, string PhoneResidence,
                                              string PhoneOffice, string Mobile, bool MaritalStatus, string Address, string EmailAddress, bool ComputerLiterate, short UserID)
    {
    
       SqlCommand SqlCom = new SqlCommand("InsertPersonalInfo", DatabaseConnection.OpenConnection());
       SqlCom.CommandType = CommandType.StoredProcedure;
    
    
      SqlParameter SqlParameterPersonalInfoID = new SqlParameter("@PersonalInfoID_Returned", SqlDbType.Int);
      SqlCom.Parameters.Add(SqlParameterPersonalInfoID);
      SqlParameterPersonalInfoID.Direction = ParameterDirection.Output;
    
      var yourVar = SqlCom.Parameters["@PersonalInfoID_Returned"].Value; //<---
    
      SqlCom.ExecuteNonQuery();
      DatabaseConnection.CloseConnection();
    
    
      return ReturnStatus;
    
    } 
