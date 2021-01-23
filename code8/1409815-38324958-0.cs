    [Route("api/profileimage/{userId}")]
    public string Get(string userId)
    {
        var image = _profileImageService.GetProfileImage(userId);
        return System.Convert.ToBase64String(image);
    }
