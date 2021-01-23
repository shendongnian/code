    var client = new HttpClient();
    var response = await client.GetAsync(new Uri("http://*******/nl/webservice/abc123/members/login?email="+ user + "&password="+ password));
    var resultlogin = await response.Content.ReadAsStringAsync(); //this is usually string type
    var obj = JsonConvert.DeserializeObject<UserLogin.RootObject>(resultbrand);
    //I usually define my own custom C# class using json2csharp.com or you can use Json.Deserialize also.
    class UserLogin
    {
        public class User
        {
            public string UserName { get; set; }
            public string Email { get; set; }
        }
        public class RootObject
        {
            public string tag { get; set; }
            public int success { get; set; }
            public int error { get; set; }
            public string uid { get; set; }
            public User User { get; set; }
        }
    } 
