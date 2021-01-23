    private AuthenticationResultEx GetResult(string token, string scope, long expiresIn)
    {
      DateTimeOffset expiresOn = (DateTimeOffset) (DateTime.UtcNow + TimeSpan.FromSeconds((double) expiresIn));
      AuthenticationResult authenticationResult = new AuthenticationResult(this.TokenType, token, expiresOn);
      ProfileInfo profileInfo = ProfileInfo.Parse(this.ProfileInfoString);
      if (profileInfo != null)
      {
        string tenantId = profileInfo.TenantId;
        string str1 = (string) null;
        string str2 = (string) null;
        if (!string.IsNullOrWhiteSpace(profileInfo.Subject))
          str1 = profileInfo.Subject;
        if (!string.IsNullOrWhiteSpace(profileInfo.PreferredUsername))
          str2 = profileInfo.PreferredUsername;
        authenticationResult.UpdateTenantAndUserInfo(tenantId, this.ProfileInfoString, new UserInfo()
        {
          UniqueId = str1,
          DisplayableId = str2,
          Name = profileInfo.Name,
          Version = profileInfo.Version
        });
      }
      return new AuthenticationResultEx()
      {
        Result = authenticationResult,
        RefreshToken = this.RefreshToken,
        ScopeInResponse = AdalStringHelper.CreateArrayFromSingleString(scope)
      };
    }
