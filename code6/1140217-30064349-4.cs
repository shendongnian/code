    // A quick & dirty example.
    public static class TryExtensions
    {
        static TryExtensions()
        {
            ExtensionProvider.Use(new TryOuts.ExtensionData.CustomerOne.ExtensionProvider());
        }
        public static void Run()
        {
            var phoneNumberOne = new PhoneNumber { NumberKind = PhoneNumber.Kind.Internal, AreaCode = "(231)", Number = "567 891 123" }.Extend();
            var phoneNumberTwo = new PhoneNumber { NumberKind = PhoneNumber.Kind.External, AreaCode = "(567)", Number = "555 666 777" }.Extend();
            Console.WriteLine("Phone Number 1: {0}", phoneNumberOne.ExtensionData.ToDictionary()["Prefix"]);
            Console.WriteLine("Phone Number 2: {0}", phoneNumberTwo.ExtensionData.ToDictionary()["Prefix"]);
            CodeThatKnowsCustomerOne(phoneNumberOne);
        }
        public static void CodeThatKnowsCustomerOne(PhoneNumber number)
        {
            var extensionData = number.ExtensionData as TryOuts.ExtensionData.CustomerOne.PhoneNumberExtension;
            Console.WriteLine("Prefix: {0}", extensionData.Prefix);
        }
    }
