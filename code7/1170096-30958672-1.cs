     public async Task<PossibleUser> FindByNameAsync(string userName)
     {
        Task<PossibleUser> task = context.TabelaStudenti.Where(apu => apu.NrMatricol == userName)
        .FirstOrDefaultAsync();
        // get result from async method
        var studentUser = await task;
        
        if (studentUser == null)
        {
            // Direct return without creating Task
            return new PossibleUser()
            {
                Password = studentUser.Parola,
                UserName = studentUser.UserName
            };
        }
        else
        {
            //just return something else
            return new PossibleUser();
        }
        return someTask;
     }
