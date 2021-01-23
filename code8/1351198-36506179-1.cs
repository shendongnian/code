            try
            {
                var verifyResponse =
                    await
                        (from acct in twitterCtx.Account
                         where acct.Type == AccountType.VerifyCredentials
                         select acct)
                        .SingleOrDefaultAsync();
                if (verifyResponse != null && verifyResponse.User != null)
                {
                    User user = verifyResponse.User;
                    Console.WriteLine(
                        "Credentials are good for {0}.",
                        user.ScreenNameResponse); 
                }
            }
            catch (TwitterQueryException tqe)
            {
                Console.WriteLine(tqe.Message);
            }
