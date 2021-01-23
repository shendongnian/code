    using System;
    namespace YourEnumNamespace
    {
        public enum ContactType : int
        {
            [Display(Name="Chief Executive Officer")]
            CEO = 0,
            
            [Display(Name="Chief Information Officer")]
            CIO = 1,
            
            [Display(Name="Regular Employee")]
            Peasant = 2
        }
    }
