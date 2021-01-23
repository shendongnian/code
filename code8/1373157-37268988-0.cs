    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Office365.OutlookServices;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private const string authority = "https://login.microsoftonline.com/common";
            private const string clientId = "blablabl-abla-blab-abla-blablablab"; // TODO: put your application id here
            private const string redirectUri = "urn:ietf:wg:oauth:2.0:oob"; // put your redirect uri here (should be the same)
            private const string scope = "https://outlook.office.com/mail.read";
    
            // we cache the token for the duration of this form
            // you could/should use the FileCache class provided in the sample here https://dev.outlook.com/restapi/tutorial/dotnet
            private TokenCache _cache = new TokenCache();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // since all packages force async,
                // we have to avoid threading issues
                BeginInvoke((Action)(() => GetMessages()));
            }
    
            private async void GetMessages()
            {
                // use the Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory nuget package for auth
                var authContext = new AuthenticationContext(authority, _cache);
                var result = await authContext.AcquireTokenAsync(
                    new[] { "https://outlook.office.com/mail.read" },
                    null,
                    clientId,
                    new Uri(redirectUri),
                    new PlatformParameters(PromptBehavior.Always, this));
    
                // use the Microsoft.Office365.OutlookServices-V2.0 nuget package from now on
                var client = new OutlookServicesClient(new Uri("https://outlook.office.com/api/v2.0"), () => Task.FromResult(result.Token));
    
                var messages = await client.Me.Messages
                                            .Take(10) // get only 10 messages
                                            .ExecuteAsync();
    
                // fill some list box
                // (beware, some messages have a null subject)
                foreach (var msg in messages.CurrentPage)
                {
                    listBox1.Items.Add(msg.Subject);
                }
            }
        }
    }
