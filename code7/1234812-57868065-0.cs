        [WebMethod]
        public List<Notifications> GetNotifications()
        {
            return objCommonModels.GetNotificationsData(1);
        }
        [WebMethod]
        public List<Notifications> GetOTPNotifications()
        {
            return objCommonModels.GetNotificationsData(2);
        }
            //Javascript
            setInterval(LoadNotifications, 3000);
    
            setInterval(LoadOTPNotifications, 3000);
