        [HttpPost]
        public String UploadFile(UserModel user)
        {
            // you'll get posted file in user.Userfile
            return user.Username;
        }
