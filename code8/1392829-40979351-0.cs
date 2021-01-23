    using System;
    using System.Threading.Tasks;
    using Twilio;
    using Twilio.Clients;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          SendSms().Wait();
          Console.Write("Press any key to continue.");
          Console.ReadKey();
        }
    
        static async Task SendSms()
        {
          var accountSid = "ACba92b39902bc361138fea39fee0a41b7"; // Your Account SID from twilio.com/console
          var authToken = "{{ auth_token }}";   // Your Auth Token from twilio.com/console
    
          TwilioClient.init(accountSid, authToken);
          var restClient = new TwilioRestClient(accountSid, authToken);
    
          var message = await
            new MessageCreator(
              new PhoneNumber("+12345678901"),  // To number
              accountSid,
              "Hello from C#"
            ).CreateAsync(restClient);
    
          Console.WriteLine(message.GetSid());
        }
      }
    }
