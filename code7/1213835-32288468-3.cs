        public async Task<ActionResult> SaveUser(ViewModel.VM_CreateUser user)
        {
            var result = await _user.Save(userDetails);
            await (new MailController().CreateUserAsync(user.userDetails)); 
            return Json(new { Success = String.IsNullOrEmpty(result) });
        }
