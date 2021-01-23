    char[] firstName = firstName.ToCharArray();
    char[] lastName = lastName.ToCharArray();
    char[] res = firstName.Except(lastName).ToArray();
    if(res.Length < 1)
    {
      res = lastName.Except(firstName).ToArray();
    }
    nameLengthDif = res.Length
