        User user = _userRepo.GetUserByEmail(userModel.Email);
        if (user == null) {
            ViewBag.Error = Resources.Account.userEmailNotExist;
            return View(userModel);
        }
        String newHashedPassword = Crypto.HashPassword(result);
        user.Password = newHashedPassword;
        user.LastPasswordChangedDate = DateTime.UtcNow;
        _userRepo.SaveChanges();
