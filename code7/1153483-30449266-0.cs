    public static class ClientEntriesExtension
    {
       public static bool ExistEmail(this IEnumerable<ClientEntry> entries, string targetEmail)
       {
           return entries.Any(x=>x.ClientEmail == targetEmail);
       }
    } 
    bool exist = clientList.ExistEmail(targetEmail)
  
