    public async Task<PossibleUser> FindByNameAsync(string userName)
    {
      Student studentUser = await context.TabelaStudenti.FirstOrDefaultAsync(st => st.NrMatricol == userName);
      if (studentUser != null)
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
    }
