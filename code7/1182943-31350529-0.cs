    public void Registeration()
    {
      // Create Token
      var TokenId = tokenRepo.Add();
      // Create user
      var UserId = userRepo.Add(TokenId, /*....params ... */);
      // Now add Bio
      var Bio = userBioRepo.Add(UserId, /*....params ... */);
    }
