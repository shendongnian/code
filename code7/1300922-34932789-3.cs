        public override async System.Threading.Tasks.Task<string> GenerateEmailConfirmationTokenAsync(string userId) {
            /* NOTE:
             * The default UserTokenProvider generates tokens based on the users's SecurityStamp, 
             * so until that changes(like when the user's password changes), the tokens will always be the same, and remain valid. 
             * So if you want to simply invalidate old tokens, just call manager.UpdateSecurityStampAsync().
             */
            //await base.UpdateSecurityStampAsync(userId);
            var token = await base.GenerateEmailConfirmationTokenAsync(userId);
            //associate the email token with the user account
            if (!string.IsNullOrEmpty(token)) {
                var x = await FindByIdAsync(userId);
                x.EmailConfirmationToken = token;
                x.EmailConfirmed = false;
                await UpdateAsync(x);
            }
            return token;
        }
        public override async System.Threading.Tasks.Task<string> GeneratePasswordResetTokenAsync(string userId) {
            var token = await base.GeneratePasswordResetTokenAsync(userId);
            if (!string.IsNullOrEmpty(token)) {
                var x = await FindByIdAsync(userId);
                x.ResetPasswordToken = token;
                await UpdateAsync(x);
            }
            return token;
        }
        public override async System.Threading.Tasks.Task<IdentityResult> ConfirmEmailAsync(string userId, string token) {
            var result = await base.ConfirmEmailAsync(userId, token);
            if (result.Succeeded) {
                var x = await FindByIdAsync(userId);
                x.EmailConfirmationToken = null;
                await UpdateAsync(x);
            }
            return result;
        }
        public override async System.Threading.Tasks.Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword) {
            var result = await base.ResetPasswordAsync(userId, token, newPassword);
            if (result.Succeeded) {
                var x = await FindByIdAsync(userId);
                x.ResetPasswordToken = null;
                await UpdateAsync(x);
            }
            return result;
        }
