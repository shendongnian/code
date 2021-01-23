        public static void Test(
            [ServiceBusTriggerAttribute("test"),
             ServiceBusAccount("testaccount")] BrokeredMessage message)
        {
            . . .
        }
