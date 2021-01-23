    public class Car
    {
        // ...
        // Other properties
        // ...
        [Required]
        public CarStateEnum CarState { get; set; }
        public string CarStateDescription
        {
            get
            {
                switch (CarState)
                {
                    case CarStateEnum.Working:
                        return "Working";
                    // ...
                    // All other enum values
                    //...
                    default:
                        return CarState.ToString();
                }
            }
        }
    }
