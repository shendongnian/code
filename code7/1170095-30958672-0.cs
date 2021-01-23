    public Task<PossibleUser> FindByNameAsync(string userName)
    {
        Student studentUser = context.TabelaStudenti.Where(st => st.NrMatricol == userName).FirstOrDefault();
        Task<PossibleUser> someTask= new Task<PossibleUser>(() =>
        {
            if (studentUser == null)
            {
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
        });
       
        // start your task
        someTask.Start();
        return someTask;
    }
