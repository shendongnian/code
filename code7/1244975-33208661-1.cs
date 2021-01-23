    public enum AttachmentFormat
    {
         xlsx = 0,
         pdf = 1
    }
   
    public class EmailManager
    {
    
       private static bool SendEmail(string to, string @from, AttachmentFormat format)
       {
          switch(format)
          {
              case AttachmentFormat.pdf: 
              // logic 
              break;
              case AttachmentFormat.xlsx: 
              // logic 
              break;
          }
       }
    }
