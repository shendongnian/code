    class MyClass
    {
        public int Selector {get;set;} // 1 or 2
        [RequiredIf("Selector == 1", ErrorMessage = "Your Error Message")]
        public string A_required_for_1 {get;set;}
        [RequiredIf("Selector == 1", ErrorMessage = "Your Error Message")]
        public string B_required_for_1 {get;set;}
        [RequiredIf("Selector == 2", ErrorMessage = "Your Error Message")]
        public string C_required_for_2 {get;set;}
        [RequiredIf("Selector == 2", ErrorMessage = "Your Error Message")]
        public string D_required_for_2 {get;set;}
        [Required("Your Error Message")]
        public string E_Required_for_both_selectors {get;set;}
     }
