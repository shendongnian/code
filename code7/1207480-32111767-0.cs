        [HttpGet]
        public Object GetProfile(string id, string returnMessage = "")
        {
            try
            {
                var profileProxy = new ProfileProxy
                                       {
                                            ReturnMessage = returnMessage
                                       }; 
                return new { Profile = profileProxy };
            }
            catch (Exception ex)
            {
                ex.LogError();
                throw;
            }
        }
        [HttpPost]
        public Object SaveProfile(JObject profile)
        {
                        var profileProxy = profile.ToObject<ProfileProxy>();
                        var returnProfile = GetProfile(profileProxy.Id.ToString()) as JObject;
                        return GetProfile(profileProxy.Id.ToString(), "New Message");
        }
