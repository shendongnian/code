    public struct CanViewClaimData
    {
        // Using const allows the compiler to generate the values in the assembly at compile time and satisfy MVC Authorize Attribute requirements for const strings.
        public const System.String Name = "CanViewClaimData";
        public const System.String DisplayName = "Can View Claim Data";
        public const System.String Description = "The allows users to view claim data";
        public const System.String DefaultErrorMessage = "You must have the \"Can View Claim Data\" permission to access this feature.";
    }
