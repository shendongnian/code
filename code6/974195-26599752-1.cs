    using System.IO;
    using System.Net.Mail;
    using Google.Apis.Gmail.v1;
    using Google.Apis.Gmail.v1.Data;
    
    public class TestEmail {
    
      public void SendIt() {
        var msg = new AE.Net.Mail.MailMessage {
          Subject = "Your Subject",
          Body = "Hello, World, from Gmail API!",
          From = new MailAddress("[you]@gmail.com")
        };
        msg.To.Add(new MailAddress("yourbuddy@gmail.com"));
        msg.ReplyTo.Add(msg.From); // Bounces without this!!
        var msgStr = new StringWriter();
        msg.Save(msgStr);
    
        var gmail = new GmailService(MyOwnGoogleOAuthInitializer);
        var result = gmail.Users.Messages.Send(new Message {
          Raw = Base64UrlEncode(msgStr.ToString())
        }, "me").Execute();
        Console.WriteLine("Message ID {0} sent.", result.Id);
      }
    
      private static string Base64UrlEncode(string input) {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        // Special "url-safe" base64 encode.
        return Convert.ToBase64String(inputBytes)
          .Replace('+', '-')
          .Replace('/', '_')
          .Replace("=", "");
      }
    }
