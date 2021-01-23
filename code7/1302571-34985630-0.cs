    public static Random numGenerator = new Random();
    ...
    string Password = Membership.GeneratePassword(12, 1);
    if(!Regex.IsMatch(Password, "\\d"))
       Password += numGenerator.GetNext(0, 10);
