    private async Task<UserProfile> getFacebookUserProfileInfo(string userId)
            {
                var claimsIdentity = await AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);
                if (claimsIdentity != null)
                {
                    var facebookAccessTokenClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type.Equals("FacebookAccessToken"));
                    if (facebookAccessTokenClaim != null)
                    {
                        var fb = new FacebookClient(facebookAccessTokenClaim.Value);
                        dynamic myInfo = fb.Get("/v2.2/me?fields=id,name,gender,about,location,link,picture.type(large)");
                        var pictureUrl = myInfo.ContainsKey("picture") ? myInfo["picture"].data["url"] : null;
                        if (!String.IsNullOrWhiteSpace(pictureUrl))
                        {
                            string filename = Server.MapPath(string.Format("~/Uploads/user_profile_pictures/{0}.jpeg", userId));
    
                            await DownloadProfileImage(new Uri(pictureUrl),                     return new UserProfile
                        {
                            Gender = myInfo.ContainsKey("gender") ? myInfo["gender"] : null,
                            FacebookPage = myInfo.ContainsKey("link") ? myInfo["link"] : null,
                            ProfilePicture = !string.IsNullOrEmpty(pictureUrl) ? string.Format("/Uploads/user_profile_pictures/{0}.jpeg", userId) : null,
                            City = myInfo.ContainsKey("location") ? myInfo["location"]["name"] : null,
                            About = myInfo.ContainsKey("about") ? myInfo["about"] : null
                        };
                    }
                }
                return null;
            }filename);
                        }
