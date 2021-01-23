    public List<QuarterlyExpenseList> GetExpenseDataQuarterly(string Id, string Year)
                {
                    string SQL = "select aspnetusers.username, SUM(case when Expense.Type='credit' and (Expense.Date>=@year+'-01-01' and Expense.Date<=@year+'-03-31') then Expense.Amount else 0 end) as QuarterOneCredits,";
                    SQL += " SUM(case when Expense.Type='credit' and (Expense.Date>=@year+'-04-01' and Expense.Date<=@year+'-06-30') then Expense.Amount else 0 end) as QuarterTwoCredits,";
                    SQL += " SUM(case when Expense.Type='credit' and (Expense.Date>=@year+'-07-01' and Expense.Date<=@year+'-09-30') then Expense.Amount else 0 end) as QuarterThreeCredits,";
                    SQL += " SUM(case when Expense.Type='credit' and (Expense.Date>=@year+'-10-01' and Expense.Date<=@year+'-12-31') then Expense.Amount else 0 end) as QuarterFourCredits,";
                    SQL += " SUM(case when Expense.Type='debit' and (Expense.Date>=@year+'-01-01' and Expense.Date<=@year+'-03-31') then Expense.Amount else 0 end) as QuarterOneDebits,";
                    SQL += " SUM(case when Expense.Type='debit' and (Expense.Date>=@year+'-04-01' and Expense.Date<=@year+'-06-30') then Expense.Amount else 0 end) as QuarterTwoDebits,";
                    SQL += " SUM(case when Expense.Type='debit' and (Expense.Date>=@year+'-07-01' and Expense.Date<=@year+'-09-30') then Expense.Amount else 0 end) as QuarterThreeDebits,";
                    SQL += " SUM(case when Expense.Type='debit' and (Expense.Date>=@year+'-10-01' and Expense.Date<=@year+'-12-31') then Expense.Amount else 0 end) as QuarterFourDebits";
                    SQL += " from Expense inner join AspNetUsers on AspNetUsers.Id=Expense.MadeBy";
                    if (Id == null)
                    {
                        SQL += " group by aspnetusers.username";
                    }
                    else
                    {
                        SQL += " where Expense.MadeBy=@id group by AspNetUsers.UserName group by aspnetusers.username";
                    }
        
                    using (IDbConnection cn=Connection)
                    {
                        cn.Open();
                        List<QuarterlyExpenseList> objList = cn.Query<QuarterlyExpenseList>(SQL, new { year = Year, id = Id }).ToList();
                        return objList;
                    }
                }
