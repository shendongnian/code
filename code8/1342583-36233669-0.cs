    public class EMailModel
    {
      int Id;
      int EmailAdd;
      bool Flag;
      bool Sent;
    }
    
    ...
    
    foreach (EmailModel email in emailList)
    {
      ...
      client.Send(msg);
      email.Sent = true;
    }
    ...
    int noOfUnsentEmails = emailList.Count(x => x.Sent == false);
    int noOfSentEmails = emailList.Count(x => x.Sent == true);
