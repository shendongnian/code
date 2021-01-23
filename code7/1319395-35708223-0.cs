            var user = new users()
            {
                Email = email,
                PasswordHash = password,
                Password = password
            };
            IdentityResult result = await UserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok();
