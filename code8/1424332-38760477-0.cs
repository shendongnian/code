    [NotMapped]
    class EmailTransmission
    {
        public string AssociatedApplication { get; set; }
        public string Key { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<EmailAddress> EmailAddresses { get; set; }
    }
