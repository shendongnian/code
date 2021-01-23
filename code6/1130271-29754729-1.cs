    ALTER PROCEDURE [dbo].[CheckUserDataBase]
     (
       @EmpNo AS VARCHAR(15), @ContractType AS VARCHAR(10)
     )
     AS 
     BEGIN
        select count(*) 
        from GeneralData 
        where EmployeeeNo = @EmpNo 
            AND ContractType= @ContractType
     END 
.
    protected void Button1_Click(object sender, EventArgs e)
    {
        int results = 0;
        using (var cn = new SqlConnection("Data Source=;Initial Catalog=Sales;User ID=;Password="))
        using (var cmd = new SqlCommand("CheckUserDataBase", cn))
        {
            cmd.CommandType=CommandType.StoredProcedure; 
            cmd.Parameters.Add("@EmpNo", SqlDbType.VarChar, 15).Value = EmployeeNo.Text;
            cmd.Parameters.Add("@ContractType", SqlDbType.VarChar, 10).Value = ContractType.Text;
 
            cn.Open();
            results = (int)cmd.ExecuteScalar();
        }
        if (results > 0)
        {
           Page.ClientScript.RegisterStartupScript(this.GetType(),"Scripts","<script>alert('The User already Exists!')</script>");
        }
        else
        {
            Response.Redirect(String.Format("Data.aspx?NumEmp={0}&ContractType={1}", 
              Server.UrlEncode(EmployeeNumber), Server.UrlEncode(ContractType)));
        }
    }
