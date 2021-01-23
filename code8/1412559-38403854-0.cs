    string Query = "Insert into Users(FirstName, LastName, Username, "
                + " Password, Role, Email, Class) "
                + " values(@fn, @sm, @user, @ps, @role, @email, @class)";
    
    SqlCommand sqlcom = new SqlCommand(Query, sqlconnection);
    
    // change the types to match SQL Column data types
    // I set all as Nvarchar as a sample
    var fnParma = new SqlParameter("@fn", SqlDbType.NVarChar);
    var smParma = new SqlParameter("@sm", SqlDbType.NVarChar);
    var userParma = new SqlParameter("@user", SqlDbType.NVarChar);
    var psParma = new SqlParameter("@ps", SqlDbType.NVarChar);
    var roleParma = new SqlParameter("@role", SqlDbType.NVarChar);
    var emailParma = new SqlParameter("@email", SqlDbType.NVarChar);
    var classParma = new SqlParameter("@class", SqlDbType.NVarChar);
    
    // Here set each value by converting it to the specified type.
    
    fnParma.Value = txtfn.Text;
    smParma.Value = txtsn.Text;
    // Continue for the result. If you have int column use Int32.Prase(Text);
    
    sqlcom.ExecuteNonQuery();
