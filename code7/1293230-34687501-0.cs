    using (SqlConnection connAM = new SqlConnection()) { // Added this above the query enclosing the second using statement. 
     connAM.ConnectionString = @"Data Source=s*****, 1433;Initial Catalog=*****;User id=*****;Password=*****;Trusted_Connection=False;MultipleActiveResultSets=true;Connection Timeout=200000";
                                                SqlCommand AccessCodeResult = new SqlCommand("SELECT [UsrAccessCode] FROM [AmSecureClose].[dbo].[PMTran] WHERE CompanyID = 3 AND UsrAccessCode LIKE '" + CleanTAccessCode + "'", connAM);
                                                connAM.Open();
                                                using (SqlDataReader AccessCodeResults = AccessCodeResult.ExecuteReader())
                                                {
