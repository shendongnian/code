        private string HttpPostRequest(string url, MultipartFormDataContent formData, Byte[] form)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            myHttpWebRequest.Method = "POST";
            myHttpWebRequest.ContentType = formData.Headers.ContentType.ToString();
            myHttpWebRequest.ContentLength = formData.Headers.ContentLength.Value;
            myHttpWebRequest.ProtocolVersion = HttpVersion.Version10;
            myHttpWebRequest.ServicePoint.ConnectionLimit = 24;
            myHttpWebRequest.KeepAlive = false;
            myHttpWebRequest.Timeout = System.Threading.Timeout.Infinite;
            myHttpWebRequest.AllowWriteStreamBuffering = false;
            System.Net.ServicePointManager.Expect100Continue = false;
            Stream requestStream = myHttpWebRequest.GetRequestStream();
            int i = 0;
            attachAttempt:
            try
            {
                requestStream.Write(form, 0, form.Length);
            }
            catch (IOException e) 
            {
                if (i < 5)
                {
                    i++;
                    goto attachAttempt;
                }
                DialogResult attachFail;
                string attachFailMessage = e.Message.ToString() + " Please check your network and try again.";
                string attachFailCaption = "Network error.";
                MessageBoxButtons emailFailButtons = MessageBoxButtons.OK;
                attachFail = MessageBox.Show(attachFailMessage, attachFailCaption, emailFailButtons, MessageBoxIcon.Error);
                return ""; 
            }
            requestStream.Close();
            
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            Stream responseStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);
            string pageContent = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            responseStream.Close();
            myHttpWebResponse.Close();
            return pageContent;
        }
