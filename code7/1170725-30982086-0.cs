           static void Main(string[] args)
            {
                GroupedMedia groupedMedia = new GroupedMedia();
                List<DigitalMedia> digitalMedias = new List<DigitalMedia>();
                for(int i = 0; i < 5; i++)
                {
                   DigitalMedia digitalMedia = new DigitalMedia();
                    digitalMedias.Add(digitalMedia);
                    digitalMedia.Author = "John";
                }
                groupedMedia.MediaList = digitalMedias;
     
     
            }
