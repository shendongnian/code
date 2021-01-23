    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.Security.Cryptography;
    using Windows.Security.Cryptography.Core;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    
    
    namespace SendNotification
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                this.sendNotification();
            }
    
            string Endpoint = "";
            string SasKeyName = "";
            string SasKeyValue = "";
    
            public void ConnectionStringUtility(string connectionString)
            {
                //Parse Connectionstring
                char[] separator = { ';' };
                string[] parts = connectionString.Split(separator);
                for (int i = 0; i < parts.Length; i++)
                {
                    if (parts[i].StartsWith("Endpoint"))
                        Endpoint = "https" + parts[i].Substring(11);
                    if (parts[i].StartsWith("SharedAccessKeyName"))
                        SasKeyName = parts[i].Substring(20);
                    if (parts[i].StartsWith("SharedAccessKey"))
                        SasKeyValue = parts[i].Substring(16);
                }
            }
    
    
            public string getSaSToken(string uri, int minUntilExpire)
            {
                string targetUri = Uri.EscapeDataString(uri.ToLower()).ToLower();
    
                // Add an expiration in seconds to it.
                long expiresOnDate = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                expiresOnDate += minUntilExpire * 60 * 1000;
                long expires_seconds = expiresOnDate / 1000;
                String toSign = targetUri + "\n" + expires_seconds;
    
                // Generate a HMAC-SHA256 hash or the uri and expiration using your secret key.
                MacAlgorithmProvider macAlgorithmProvider = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha256);
                BinaryStringEncoding encoding = BinaryStringEncoding.Utf8;
                var messageBuffer = CryptographicBuffer.ConvertStringToBinary(toSign, encoding);
                IBuffer keyBuffer = CryptographicBuffer.ConvertStringToBinary(SasKeyValue, encoding);
                CryptographicKey hmacKey = macAlgorithmProvider.CreateKey(keyBuffer);
                IBuffer signedMessage = CryptographicEngine.Sign(hmacKey, messageBuffer);
    
                string signature = Uri.EscapeDataString(CryptographicBuffer.EncodeToBase64String(signedMessage));
    
                return "SharedAccessSignature sr=" + targetUri + "&sig=" + signature + "&se=" + expires_seconds + "&skn=" + SasKeyName;
            }
    
    
            public async void sendNotification()
            {
                ConnectionStringUtility("YOURHubFullAccess"); //insert your HubFullAccess here (a string that can be copied from the Azure Portal by clicking Access Policies on the Settings blade for your notification hub)
    
                //replace YOURHUBNAME with whatever you named your notification hub in azure 
                var uri = Endpoint + "YOURHUBNAME" + "/messages/?api-version=2015-01";
                string json = "{\"data\":{\"message\":\"" + "Hello World!" + "\"}}";
               
                //send an HTTP POST request
                using (var httpClient = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, uri);
                    request.Content = new StringContent(json);
    
                    request.Headers.Add("Authorization", getSaSToken(uri, 1000));
                    request.Headers.Add("ServiceBusNotification-Format", "gcm");
                    var response = await httpClient.SendAsync(request);
                    await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
