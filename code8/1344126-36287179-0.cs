    public static class BalanceHelper
    {
       public static Balance GetBalance(this Balance balance)
       {
          if(balance != null)
          {         
             balance.value = balance.Earnings.Sum(x => x.EarningValue) - 
                               balance.Expenses.Sum(x => x.ExpenseValue);
          }
          return balance; 
       }
    }
