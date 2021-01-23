    public class IvrBalanceInfo
    {
       public decimal Amount { get; set; }
       public IvrBalanceType Type { get; set; }
       public IvrBalanceInfo(BalanceInfo info, BalanceType type)
       {
          Amount = info.Amount;
          if (type == BalanceType.Available)
             Type = IvrBalanceType.Available;
          else if(type == BalanceType.Phone)
             Type = IvrBalanceType.Phone
          
          // here you have to handle the other values and set the default
          // values for the Type Property or it will take the default value
          // if you not set it
       }
       public enum IvrBalanceType // new enum
       {
           Available,
           Phone,
       }
    }
