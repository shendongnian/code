        [RewardValidation]
        public class RewardModel
        {
            public string Address { get; set; }
            [DisplayName("Do you want Reward ؟")]
            public bool IsReward { get; set; }
        
            [Range(0, int.MaxValue, ErrorMessage = "Please enter integer number")]
        
            [DisplayName("Reward")]
            public int Reward { get; set; }
        }
    
    public class RewardValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            RewardModel app = value as RewardModel;
            if (app.IsReward && app.Reward==0)
            {
                ErrorMessage = "please enter Reward";
               
                return false;
            }
            return true;
        }
    }
