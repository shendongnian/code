    using Newtonsoft.Json;
    public string Demo()
    {
        var mail = new Mail
        {
            To = new Recepient { 
            EntryType = 2, 
            username = "jack",
            email = "test@gmail.com
        }
    
        return JsonCovert.SerializeObject(mail);
    }
