    string email = "VINCENT.NAPOLITAIN@XXXX.EU"; 
    string names = email.Split('@')[0];
    string name = "";
    string surname = "";
    if (names.Contains('.'))
    {
        var nameSurname = names.Split('.');
        name = nameSurname[0]; //
        surname = nameSurname[1];
    }
