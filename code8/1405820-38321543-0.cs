            try
            {
                if (!(e.Url.ToString().ToLower().Contains("file") || e.Url.ToString().ToLower().Contains("pdf")))
                {
                    e.Cancel = true;
                    //Open file
                    Process.Start(e.Url.ToString());
                }
            }
            catch (Exception err)
            {
               //Handle Exception
            }
        }
