    var userInfo = new UserInfo() {
                Action = "user_info",
                Message = "success",
                Data = new Data() {
                    ProfileInformation = new ProfileInformation() {
                        Querying = "0",
                        TpsList = new List<Tps>() {
                            new Tps() {
                                Active="0",
                                FileHash = "hash",
                                IconPath="",
                                LastUse= DateTime.MinValue,
                                ProfileUrl = "anotherfakeurl",
                                ProfilePicture = "fakeurl",
                               Selected = "1",
                               TimeOfInsertion = DateTime.MinValue,
                               TpId = 1,
                               TpUserId = 1377839182243200L,
                               UserDisplay = "it's a me",
                               UserId = 4
                            } } } } };
        string json = JsonConvert.SerializeObject(userInfo, Formatting.Indented);
        var newUserInfo = JsonConvert.DeserializeObject<UserInfo> (json);
        Assert.AreEqual(newUserInfo.Data.ProfileInformation.TpsList.Count,1);
        Assert.AreEqual(newUserInfo.Data.ProfileInformation.TpsDict.Count,1);
