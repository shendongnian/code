     public static void Load_Image1(string name1, string name2, string name3,string LocationName)
    {
        var startPath = Application.StartupPath;
        string Imagefolder = Path.Combine(startPath, "Image");
        string subImageFolder = Path.Combine(Imagefolder, LocationName);
        System.IO.Directory.CreateDirectory(subImageFolder);
        //string Jpeg = Path.Combine(Environment.CurrentDirectory, subImageFolder);
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        pictureBoxes.Add(Image1);
        pictureBoxes.Add(Image2);
        pictureBoxes.Add(Image3);
        using (var wc = new System.Net.WebClient())
        {
            var uri = ("https://en.wikipedia.org/w/api.php?action=query&prop=imageinfo&format=json&iiprop=url&iiurlwidth=400&titles="+name1+"|"+name2+"|"+name3);
            var response = wc.DownloadString(new Uri(uri));
            var responseJson = JsonConvert.DeserializeObject<RootObject>(response);
            List<string> urls = new List<string>();
            foreach (KeyValuePair<string, Pageval> entry in responseJson.query.pages)
            {
                var url = entry.Value.imageinfo.First().thumburl;
                urls.Add(url);
                var hash = url.GetHashCode();
                string Jpeg = Path.Combine(Environment.CurrentDirectory, subImageFolder);
                var path = Path.Combine(Jpeg, hash.ToString("X") + ".jpg");
                wc.DownloadFile(url, path);
            }
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                Image1.SizeMode = PictureBoxSizeMode.StretchImage;
                Image2.SizeMode = PictureBoxSizeMode.StretchImage;
                Image3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxes[i].Load(urls[i]);
                
              }
           }
        }
     }
