    private void getResponse(IAsyncResult result)
    {
        HttpWebRequest request = result.AsyncState as HttpWebRequest;
        if (request != null)
        {
            try
            {
                WebResponse response = request.EndGetResponse(result);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                string read = streamRead.ReadToEnd();
                deserializeJsonString(read);
                List<lstData> list = new List<lstData>();
                lstData lstObj = new lstData();
                CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                  foreach (var itm in childList.AppData)
                  {
                    lstObj.app_name = Convert.ToString(itm.app_name);
                    lstObj.app_url = Convert.ToString(itm.app_url);
                    list.Add(lstObj);
                  }
                    mylistbox.ItemsSource = list;
                 });
            }
            catch (WebException e)
            {
                // Debug.WriteLine("Exception in getResponse" + e);
            }
        }
    }
