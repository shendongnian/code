    bool IsSuccessfullySent;
    try
    {
     SendEmail(BuildEmailBody(transaction, myHomeInformation),subjectLine);
     IsSuccessfullySent= true;
    }
    catch(Exception ex)
    {
     IsSuccessfullySent=false;
    }
    if (IsSuccessfullySent)
     {
       BOAssistant.WriteLine                 
     }
