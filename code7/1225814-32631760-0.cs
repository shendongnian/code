            public void LinkBuilder(string baselink, string sharedkey, string service, string period, string bulletintype,
                string includeresults, string includemap, string username, string password)
        {
            var allParams = new List<string>
            {
                baselink,
                sharedkey,
                service,
                period,
                bulletintype,
                includeresults,
                includemap,
                username,
                password
            };
            var completeLink = "?" + String.Join("&", allParams.Select(p => p != null));
        }
