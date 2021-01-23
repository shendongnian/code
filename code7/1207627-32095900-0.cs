    conn.open()
    int CheckDb;
    String Command1 = "select * from [ClinRefFileTypeMaster] where [ClinRefTypeName] = @ClinRefFileTypeId";
    using (SqlCommand ClinRefFileTypeMaster = new SqlCommand(command1, con);
        {
             cmd.Parameters.AddWithValue("@ClinRefFileTypeId", {0});
             CheckDb = (int)ClinRefFileTypeMaster.ExecuteScalar();
         }
    If (CheckDb != 0)
        //Logic for returning the value from the database
    Else
        //Here you can request user check data or insert the value into the database.
