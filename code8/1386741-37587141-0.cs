Extend you ACurrentDayInfo class with a getter like this
    class  ACurrentDayInfo
    {
        public string UserName
        {
            get
            {
                return JsonConvert.DeserializeObject<UserInfo>(UserInfo).RealName ?? "";
            }
        }
    }
