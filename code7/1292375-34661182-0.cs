    Create Table Customer
    (
        Id Int Identity(1,1), 
        Name varchar(50)
    )
    Create Proc NewCustomer 
    (
        @Name varchar(50)
    )
    As
    (
        DECLARE @custID Int
        SET NOCOUNT ON
        INSERT INTO Customer (Name) Values('Your Name')
        SET @custID = SCOPE_IDENTITY()
        RETURN @custID
    )
    protected void btnNew_Click(object sender, EventArgs e)
    {
            Clear();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NewCustomer";
    
            conn.Open();
            SqlParameter name = new SqlParameter();
            name.ParameterName = "@Name";
            name.Direction = ParameterDirection.Input;
            name.SqlDbType = SqlDbType.Varchar;
            name.Value = "Your Name";
            command.Parameters.Add(name);
            SqlParameter returnValue= new SqlParameter();
            returnValue.ParameterName = "@custID";
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(maxid);
    
            command.ExecuteNonQuery();                       
    
            NewCustId = Convert.ToInt32(returnValue.Value);
    
            txtCustID.Text = (NewCustId).ToString();
            txtCustID.DataBind();
    
            conn.Close();
    }
