    class Phone
    {
        public int ID { get; set; }
        public string IMEI { get; set;}
        public virtual ICollection<Person> People { get; set; }
        public void Encrypt()
        {
            Encryptor.Encrypt(IMEI);
        }
    }
    
    class Person
    {
        public int ID { get; set; }
        public int PhoneId { get; set; }
        public virtual Phone Purchase { get; set; }
    
        public void Encrypt()
        {
            Purchase.Encrypt();
        }
    }
