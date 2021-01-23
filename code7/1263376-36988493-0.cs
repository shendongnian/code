       private static BoxClient BoxClient(string user)
        {
            var filePath = HttpContext.Current.Server.MapPath("~/App_Data/private_key.pem");
            var privateKey = File.ReadAllText(filePath);
            var boxConfig = new BoxConfig(CLIENT_ID, CLIENT_SECRET, ENTERPRISE_ID, privateKey, JWT_PRIVATE_KEY_PASSWORD,
                JWT_PUBLIC_KEY_ID);
            var boxJWT = new BoxJWTAuth(boxConfig);
            var userToken = boxJWT.UserToken(user); 
            var userClient = boxJWT.UserClient(userToken, user); 
            return userClient;
        }
