    public class UserStat {
 
       public double MoneyRate { get; set; }
       public string ColumnNormal {get; set;} 
       public UserStat() { }
       public UserStat(double moneyRate, string columnNormal)
       {
           MoneyRate = moneyRate;
           ColumnNormal = columnNormal;
       }
    }
