    public class MyClass : IMyspace
    {    
        public string result(string url)
        {
          var target = new System.Uri(url);
          var httpRequest = (HttpWebRequest) HttpWebRequest.Create(target);
            //do whatever stuff you trying to do here and just return  
              whatever you want 
        }
    }
