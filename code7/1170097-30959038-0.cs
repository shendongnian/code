    public Task<PossibleUser> FindByNameAsync(string userName)
    {
        return context.TabelaStudenti
            .FirstOrDefaultAsync(st => st.NrMatricol == userName)
            .ContinueWith(task =>
            {
                var studentUser = task.Result;
                if (studentUser != null)
                {
                    return new PossibleUser
                    {
                        Password = studentUser.Parola,
                        UserName = studentUser.UserName
                    };
                }
                //just return something else
                return new PossibleUser();
            });
    }
