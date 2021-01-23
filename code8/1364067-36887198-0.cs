    List<string> inputMails = "mark345345@test.com;rtereter@something.com;terst@gmail.com;fault@mail".Split(';').ToList();
    List<string> validMails = new List<string>();
    List<string> inValidMails = new List<string>();
    var validator = new EmailAddressAttribute();
    foreach (var mail in inputMails)
    {
        if (validator.IsValid(mail))
        {
            validMails.Add(mail);
        }
    
        else
        {
            inValidMails.Add(mail);
        }
    }
