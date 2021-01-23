     public static void SetLiveTile()
        {
        
            String[] arrayImage = new String[] { "A.PNG", "B.PNG", "C.PNG" };
        
            int tileCount = arrayImage.Length;
            if (5 < tileCount)
                tileCount = 5;
        
            TileUpdateManager.CreateTileUpdaterForApplication().Clear();
            TileUpdateManager.CreateTileUpdaterForApplication().EnableNotificationQueue(true);
         
            for (int index = 0; index < tileCount; index++)
            {
                XmlDocument tileWideXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideImage);
        
                XmlNodeList tileImageAttribute = tileWideXml.GetElementsByTagName("image");
                ((XmlElement)tileImageAttribute[0]).SetAttribute("src", arrayImage[index]);
        
                TileNotification tileNotification = new TileNotification(tileWideXml);
                DateTimeOffset time = DateTime.Now;
                //Note: You can dynamically set the value or you can update to your value here.
                //Add 5 seconds here. 
                time.AddSeconds(5);
                Windows.UI.Notifications.ScheduledTileNotification stf = new ScheduledTileNotification(tileWideXml, time);
     
                TileUpdateManager.CreateTileUpdaterForApplication().AddToSchedule(stf);
           
                TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
            }
        }
