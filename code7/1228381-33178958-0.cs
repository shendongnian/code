            //Create TextView to display status of Wifi
           TextView wifitext = FindViewById<TextView>(Resource.Id.WifiTextView);
           
            //Configuring Wifi connection
            var connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            var activeConnection = connectivityManager.ActiveNetworkInfo;
          
            if (activeConnection != null && activeConnection.IsConnected)
            {
                wifitext.Text = "WIFI AVAILABLE";
                string[] urladdress = new string[] { "https://www.google.com/", "https://www.yahoo.com/"};
                for (int i = 0; i < urladdress.Length; i++)
                {
                    string url = urladdress[i];
                    //Call async method
                    Task returnedTask = Task_MethodAsync(url);
                }
                               
             }
            else
               wifitext.Text = "WIFI UNAVAILABLE";        
        }
        public async Task Task_MethodAsync(string url)
        {
            LinearLayout ll = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            
            WebClient client = new WebClient();
           Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Stream listurl = client.OpenRead(url);
            StreamReader reader = new StreamReader(listurl);
            stopwatch.Stop();
            // listurl.Close();
            var time = Convert.ToString(stopwatch.Elapsed); 
