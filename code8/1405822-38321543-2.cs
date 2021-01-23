    private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
            {
                try
                {
                    if (!(e.Url.ToString().ToLower().Contains("file") || e.Url.ToString().ToLower().Contains("pdf")))
                    {
                        e.Cancel = true;
                        //Open Link
                        Process.Start(e.Url.ToString());
                    }
                }
                catch (Exception err)
                {
                   //Handle Exception
                }
            }
