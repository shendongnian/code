    public AuthInfoDTO GetAuthInfo(List<string> roles)
            {
                AuthInfoDTO obj = new AuthInfoDTO();
    
                if (roles.Any(x => x == "Admin"))
                {
                    obj.SlidingExpiration = true;
                    ExpireTimeSpan = new TimeSpan(10, 1, 0, 0, 0);
                }
                else
                {
                    obj.SlidingExpiration = false;
                    ExpireTimeSpan = new TimeSpan(0, 1, 0, 0, 0);
                }
                return obj;
            }
