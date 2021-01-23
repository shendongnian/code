        public ActionResult Get()
        {
            var identity = this.User.Identity as WindowsIdentity;
             if (identity != null)
            {
                var data = new WindowsUserInformation { 
                              Name = identity.Name, 
                              AccountDomainSid = identity.User.AccountDomainSid.Value, 
                              CreationDate = DateTime.UtcNow 
             };
