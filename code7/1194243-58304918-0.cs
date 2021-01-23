     catch (WebException ex)
     {
                HttpWebResponse httpResponse = (HttpWebResponse)ex.Response;
                using (WebResponse response = ex.Response)
                using (Stream data = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(data))
                {
                    string errorMessage = reader.ReadToEnd();
                }
     }
