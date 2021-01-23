    class MyClass
    {
        // ....
    
        [Browsable(false)]
        public byte[] Password { get; set; }
    
        [DisplayName("Password")]
        public string PasswordText
        {
            get { ... }
        }
    }
