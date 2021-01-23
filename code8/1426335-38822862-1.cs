    public sealed class ContactModel
    {
        /* omitted other attributes */
        public string EmailAddress { get; set; }
        
        [CompareEnhanced("EmailAddress", AllowEmptyStrings = true)]
        public string ConfirmEmailAddress { get; set; }
    }
