    public static int CreateDocumentNumber(string userId, string todaysDate, decimal docprice, decimal docpaid, int packageId, int orderstatus)
    {
        //create order 
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string insertSql = "INSERT INTO [dbo].[LD_Orders](TD_OrdUserID, TD_OrdDate, TD_OrdCost, TD_OrdPaid, TD_OrdPackage, TD_OrdStatus)" +
            " VALUES (@UserId, @Date, @Cost, @Paid, @Package, @Status);SELECT SCOPE_IDENTITY()";
        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            myConnection.Open();
            int orderId = myConnection.Query<int>(
                insertSql,
                new {
                       UserId = userId,
                       Date = todaysDate,
                       Cost = docprice,
                       Paid = docpaid,
                       Package = packageId,
                       Status = orderstatus
                    }).Single();
        }
        return orderId;
    }
