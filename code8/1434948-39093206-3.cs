    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void myBtn_Click(object sender, RoutedEventArgs e)
        {
            var translatedText = await Translate("Text for test");
            myTB.Text = translatedText;
        }
        //Exits on the WebResponse line
        private static async System.Threading.Tasks.Task<string> DetectMethod(string authToken, AdmAccessToken token, string txtToTranslate)
        {
            string headerValue = "Bearer " + token.access_token;
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + WebUtility.UrlEncode(txtToTranslate) + "&from=en&to=es";
            WebRequest translationWebRequest = WebRequest.Create(uri);
            translationWebRequest.Headers["Authorization"] = headerValue;
            WebResponse response = await translationWebRequest.GetResponseAsync(); //where it's exiting
            System.IO.Stream stream = response.GetResponseStream();
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            System.IO.StreamReader translatedStream = new System.IO.StreamReader(stream, encode);
            System.Xml.XmlDocument xTranslation = new System.Xml.XmlDocument();
            xTranslation.LoadXml(translatedStream.ReadToEnd());
            //translatedText = xTranslation.InnerText;
            return xTranslation.InnerText;
        }
        //Where DetectMethod is called from
        public static async System.Threading.Tasks.Task<string> Translate(string TextToTranslate)
        {
            AdmAccessToken admToken;
            string headerValue;
            string translatedText=null;
            AdmAuthentication admAuth = new AdmAuthentication("<>", "<>");//codes removed
            try
            {
                admToken =await admAuth.GetAccessToken();
                // Create a header with the access_token property of the returned token
                headerValue = "Bearer " + admToken.access_token;
                translatedText= await DetectMethod(headerValue, admToken, TextToTranslate); //calls previous method
            }
            catch (WebException e)
            {
                
            }
            return translatedText;
        }
        public class AdmAccessToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public string expires_in { get; set; }
            public string scope { get; set; }
        }
        public class AdmAuthentication
        {
            string clientID = "winffee_4960";
            string clientSecret = "N0aTQ4OUKKP5lpNIBs0h9wfFXGpHlel1BpIkmDd1cVE=";
            String strTranslatorAccessURI = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
            String strRequestDetails;
            public AdmAuthentication(String str1, String str2)
            {
                strRequestDetails= string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", WebUtility.UrlEncode(clientID), WebUtility.UrlEncode(clientSecret));
                
            }
            public async Task<AdmAccessToken> GetAccessToken()
            {
                WebRequest webRequest = System.Net.WebRequest.Create(strTranslatorAccessURI);
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(strRequestDetails);
                //webRequest.ContentType = bytes.Length;
                using (Stream outputStream = await webRequest.GetRequestStreamAsync())
                {
                    outputStream.Write(bytes, 0, bytes.Length);
                }
                WebResponse webResponse = await webRequest.GetResponseAsync();
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(AdmAccessToken));
                //Get deserialized object from JSON stream 
                AdmAccessToken token = (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());
                string headerValue = "Bearer " + token.access_token;
                return token;
            }
        }
    }
