    public class MyValidator : Validator<UserAccount>
    {
        private static int? _countOfExistingMails;
        public MyValidator()
        {
            CallEmailValidations();
            // other rules...
        }
    }
