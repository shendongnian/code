     public class Authorization
            {
                public string result { get; set; }
    
            }
    
            public class UserAuthorization
            {
                public string userName { get; set; }
                public string password { get; set; }
                public string helpText { get; set; }
    
            }
    
            GetDataAPI GetData = new GetDataAPI();
               
      /// <summary>
      /// 
      /// </summary>
      /// <param name="userAuth"></param>
      /// <returns></returns>
           public HttpResponseMessage ValidateUser(UserAuthorization userAuth)
            {
                Authorization auth = new Authorization();
                string Result = Convert.ToString(GetData.IsLogin(userAuth.userName, userAuth.password));
                auth.result = Result;
                string response = JsonConvert.SerializeObject(auth);
                var resp = new HttpResponseMessage()
                {
    
                    Content = new StringContent(response)
                };
                return resp;
            }
