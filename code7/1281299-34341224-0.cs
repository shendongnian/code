    public class IvrBalanceInfo
    {
        public decimal Amount { get; set; }
        public IvrBalanceType Type { get; set; }
        public IvrBalanceInfo(BalanceInfo info, BalanceType type)
        {
            Amount = info.Amount;
            Type = (IvrBalanceType)(int)type;
        }
    
        public enum IvrBalanceType // new enum
        {
            Available,
            Phone,
        }
    }
