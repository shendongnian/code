     ComEngine.Connection = new HubConnection(BaseEngine.ServerURI);
     ComEngine.Connection.Headers.Add("AuthenticationToken", Encryptor.Encrypt(string.Format("{0};{1};{2}", BaseEngine.UserName, BaseEngine.DeviceId, BaseEngine.Password), Encryptor.Password));
     try
     {
         await Connection.Start();
     }
     catch (Exception ex)
     {
         ...
     }
