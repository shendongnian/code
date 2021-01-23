    public sealed partial class ConfirmaSMS : ContentDialog
    {
        Frame rootFrame = Window.Current.Content as Frame;
        public ConfirmaSMS()
        {
            this.InitializeComponent();
        }
        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            String _confirmaSms = "https://www.Example.com";
            RestClient client = new RestClient();
            string msisdn = PrimaryButtonCommandParameter.ToString();
            string codigoConfirmacao = txtCodigoConfirmacao.Text;
            string output = JsonConvert.SerializeObject(usuario);
            //Debug.WriteLine(output);
            string response = await client.RestConnection(_confirmaSms, "POST", output);
            JObject responseObj = JObject.Parse(response);
            JObject resultObj = (JObject)responseObj["result"];
            string result = resultObj["codesms"].ToString();
            if (usuario.codesms.ToString() == result && result != null)
            {
                Debug.WriteLine(result.ToString());
                rootFrame.Navigate(typeof(HomePage));
            }
            else
            {
                confirmaSMS.SecondaryButtonCommandParameter = false;
                confirmaSMS.Hide();
            }
            Debug.WriteLine(resultObj["ltoken"]);
            
        }
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
        
        
    }
