    public class InsuranceDialogForm
    {
        public IsCurrentCustomer? IsCurrentCustomer;
    
        //[Prompt("Which type of insurance do you need?")]
        public InsuranceType? InsuranceType;
    
        //[Prompt("Which country are you travelling to?")]
        public string TravelDestination;
    
        //[Prompt("Please select one:")]
        public InsurancePackage? InsurancePackage;
    }
