         protected void Application_Start()
         {
           //Rest of the code 
           Mapper.Initialize(c => c.AddProfiles(new string[] { "DLL NAME OF YOUR PROFILE CLASS" }));
         }
