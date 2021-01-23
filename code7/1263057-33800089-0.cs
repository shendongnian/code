      public async void HTTP(object sender, RoutedEventArgs e)
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://msdn.microsoft.com/en-us/library/system.net.httpwebresponse.getresponsestream(v=vs.110).aspx");
                HttpWebResponse response = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                Stream resStream = response.GetResponseStream();            
    
                StringBuilder sb = new StringBuilder();
    
                StreamReader read = new StreamReader(resStream);
                string tmpString = null;
                int count = (int)response.ContentLength;
                int offset = 0;
                Byte[] buf = new byte[count];
                do
                {
                    int n = resStream.Read(buf, offset, count);
                    if (n == 0) break;
                    count -= n;
                    offset += n;
                    tmpString = Encoding.ASCII.GetString(buf, 0, buf.Length);
                    sb.Append(tmpString);
                } while (count > 0);
    
                text.Text = tmpString;
    
    
                read.Dispose();
    
                //using (StreamReader read = new StreamReader(resStream))
                //{
                //    var result = await read.ReadToEndAsync();
                //    text.Text = result;
                //    read.Dispose();
                //}
    
                response.Dispose();
    
            }
