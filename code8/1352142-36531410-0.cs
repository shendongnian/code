            string imageUrl = @url;
            string img_name = imageUrl.Replace("http://i.imgur.com/", "");
            string saveLocation = @"C:\folder_name\" + img_name;
            byte[] imageBytes;
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
            WebResponse imageResponse = imageRequest.GetResponse();
            Stream responseStream = imageResponse.GetResponseStream();
            using (BinaryReader br = new BinaryReader(responseStream))
            {
                imageBytes = br.ReadBytes(500000);
                br.Close();
            }
            responseStream.Close();
            imageResponse.Close();
            FileStream fs = new FileStream(saveLocation, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(imageBytes);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
            return img_name;
        }
        private string download_img2(string url)
        {
            string imageUrl = @url;
            string img_name = imageUrl.Replace("http://i.imgur.com/", "");
            string saveLocation = @"C:\ssulf\" + img_name;
            byte[] imageBytes;
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
            WebResponse imageResponse = imageRequest.GetResponse();
            Stream responseStream = imageResponse.GetResponseStream();
            using (BinaryReader br = new BinaryReader(responseStream))
            {
                // imageBytes = br.ReadBytes(500000);
                imageBytes = br.ReadBytes(1000000);
                br.Close();
            }
            responseStream.Close();
            imageResponse.Close();
           
            FileStream fs = new FileStream(saveLocation, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(imageBytes);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
            return img_name;
        }
