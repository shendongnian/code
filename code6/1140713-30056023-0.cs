string inputEmails = "First1, Last1 <email1@example.com>; First2, Last2 <email2@example.com>;";
string[] inputEmailsArray = inputEmails.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
foreach (string email in inputEmailsArray)
{
    string[] inputEmailArray = email.Split(new char[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string emailPart in inputEmailArray)
    {
        string s = emailPart;   // First1, Last1     // email1@example.com
    }
}
