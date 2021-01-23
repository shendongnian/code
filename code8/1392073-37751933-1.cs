    private void test()
    {
        ojson myjson = new ojson();
        List<Email> myemails=new List<Email>();
        Email email = new Email();
        email.email = "";
        Email email2 = new Email();
        email2.email = "";
        myemails.Add(email);
        myemails.Add(email2);
        myjson.emails = myemails;
    }
    public class Email
    {
        public string email { get; set; }
    }
    public class Phone
    {
        public string number { get; set; }
    }
    public class ojson
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string type { get; set; }
        public string street { get; set; }
        public List<Email> emails { get; set; }
        public List<Phone> phone { get; set; }
    }
