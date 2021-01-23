      var userName = u.GetUserPassword(username));
      for (int i = 0; i < userName.Length; ++i)
        for (int j = i + 1; j < userName.Length; ++j)
          if (newPassword.Contains(userName.Substring(i, j - i)))
            Assert.Fail();
    
