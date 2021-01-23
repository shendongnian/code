    using System;
    using Twilio;
    class Example
    {
      static void Main(string[] args)
      {
        // Find your Account Sid and Auth Token at twilio.com/user/account
        string AccountSid = "{{ account_sid }}";
        string AuthToken = "{{ auth_token }}";
     
        var twilio = new TwilioRestClient(AccountSid, AuthToken);
        var message = twilio.SendMessage("+14158141829", "+14159352345", "This text message was sent with code!");
     
        Console.WriteLine(message.Sid);
      }
    }
