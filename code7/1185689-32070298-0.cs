      AccessToken = Properties.Settings.Default.FBAccessToken;
        FacebookClient FbClient = new FacebookClient(AccessToken);
        var PostInfo = new Dictionary<string, object>();
        var tags = new[] { new { tag_uid = "870415313026255", tag_text = "Tag updated", x = 90, y = 110 } };
        PostInfo.Add("tags", tags);
        var result = FbClient.Post("/"Existing PhotoID"/tags", PostInfo);
