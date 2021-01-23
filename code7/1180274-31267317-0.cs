       try
        {
           using(responseFile = (HttpWebResponse)requestFile.GetResponse())
           {
               ...your code...
           }
        }
        catch (WebException exRequestFile)
        {
            MessageBox.Show(exRequestFile.Message);
            closeRequest = false;
        }
