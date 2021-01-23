    DropNetClient client = new DropNetClient(variable.ApiKey, variable.ApiSecret);
               
    
             
    ]
               var response =client.GetToken();
                var t = response.Token;
                var s = response.Secret;
                Console.WriteLine(s);
                Console.WriteLine(t);
                var authorizeUrl = client.BuildAuthorizeUrl(new DropNet.Models.UserLogin
                {
                    Secret = s,
                    Token = t
                 
                }
                    );
    
                DropNetClient client2= new DropNetClient(variable.ApiKey, variable.ApiSecret,t,s);
                
    
                // Prompt for user to auth
                Process.Start(authorizeUrl);
                // PRESS KEY AFTER authorization AFTER
                Console.ReadKey();
                
              // If the user authed, let's get that token
              try
                {
                    var Token = client2.GetAccessToken();
                    var userToken = Token.Token;
                    var userSecret = Token.Secret;
                    Console.WriteLine(userSecret);//ACCESS TOKEN SECRET
                    Console.WriteLine(userToken);//ACCESS TOKEN
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception! " + e.Message);
                    Console.ReadKey();
                    
                }
                // save for later
                   
