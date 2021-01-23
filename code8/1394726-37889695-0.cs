    // source
    class User
    {
        public string UserTitle { get; set; }
    }
    // target
    class UserViewModel
    {
        public string VM_Title { get; set; }
        public string VM_OtherValue { get; set; }
    }
    // intermediate from ValueResolver
    class UserTitleParserResult
    {
        public string TransferTitle { get; set; }
    }
    class TypeValueResolver : ValueResolver<User, UserTitleParserResult>
    {
        protected override UserTitleParserResult ResolveCore(User source)
        {
            return new UserTitleParserResult { TransferTitle = source.UserTitle };
        }
    }
