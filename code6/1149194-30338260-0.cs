    private static void SaveImageFromUrl(string folderName, string fileName, string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (Stream stream = httpWebReponse.GetResponseStream())
                    {
                        //need to call this method here, since the image stream is not disposed
                        SaveImage(folderName, fileName, stream);
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("Image with URL " + url + " not found." + e.Message);
            }
        }
        private static void SaveImage(string folderName, string fileName, Stream img)
        {
            if (img == null || folderName == null || folderName.Length == 0)
            {
                return;
            }
            string path = "D:\\Files\\" + folderName;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (var fileStream = File.Create("D:\\Files\\" + folderName + "\\" + fileName))
            {
                img.CopyTo(fileStream);
                //close the stream from the calling method
                img.Close();
            }
        }
    SaveImageFromUrl(folderName, fileName, resultUrl);
