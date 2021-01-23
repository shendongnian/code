    class Image
    {
        public static PictureBox Image1 = new PictureBox();
        public static PictureBox Image2 = new PictureBox();
        public static PictureBox Image3 = new PictureBox();
        public static void Load_Image1()
        {
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            pictureBoxes.Add(Image1);
            pictureBoxes.Add(Image2);
            pictureBoxes.Add(Image3);
            using (var wc = new System.Net.WebClient())
            {
                var uri = ("https://en.wikipedia.org/w/api.php?action=query&prop=imageinfo&format=json&iiprop=url&iiurlwidth=400&titles=File%3ALuftbild%20Flensburg%20Schleswig-Holstein%20Zentrum%20Stadthafen%20Foto%202012%20Wolfgang%20Pehlemann%20Steinberg-Ostsee%20IMG%206187.jpg%7CFile%3AHafen%20St%20Marien%20Flensburg2007.jpg%7CFile%3ANordertor%20im%20Schnee%20(Flensburg%2C%20Januar%202014).JPG");
                var response = wc.DownloadString(new Uri(uri));
                var responseJson = JsonConvert.DeserializeObject<RootObject>(response);
    
                List<string> urls = new List<string>();
                foreach (KeyValuePair<string, Pageval> entry in responseJson.query.pages)
                {
                    var url = entry.Value.imageinfo.First().thumburl;
                    urls.Add(url);                        
                }
                // if you're sure that you're getting always at least 3 images, this will work
                for(int i = 0; i < pictureBoxes.Count; i++)
                {
                    pictureBoxes[i].Load(urls[i]);
                }
            }
        }
    }
