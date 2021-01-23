    public Account EditAccount(int id, JsonPatchDocument patch)
        {
            var account = _context.Accounts.Single(a => a.AccountId == id);
            var uneditablePaths = new List<string> { "/accountId" };
            if (patch.Operations.Any(operation => uneditablePaths.Contains(operation.path)))
            {
                throw new UnauthorizedAccessException();
            }
            patch.ApplyTo(account);            
            return account;
        }
