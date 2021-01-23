    var url = "http://www.avito.ru/nizhniy_novgorod/kvartiry/sdam/na_dlitelnyy_srok?q=%D0%93%D0%B5%D0%BD%D0%B5%D1%80%D0%B0%D0%BB%D0%B0+%D0%98%D0%B2%D0%BB%D0%B8%D0%B5%D0%B2%D0%B0+10%D0%BA1";
            string html = "";
            try
            {
                Uri uri = new Uri(uri);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 100000;
                
                using (HttpWebResponse responce = (HttpWebResponse)request.GetResponse())
                {
                    Stream stream = responce.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    html = reader.ReadToEnd();
                    Console.WriteLine(html);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
 
