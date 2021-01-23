     var password = "password_to_test";
     if (password.Any("!@#$%^&*".Contains)
      && password.Any(char.IsDigit)
      && password.Any(char.IsLower)
      && password.Any(char.IsUpper))
      {
          //valid!
      }
