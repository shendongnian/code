            MainPage.WebParts[0].Hidden = true;
            MainPage.SaveChanges(MainPage.WebParts[0]);
            try
            {
                var linqqry = from wp in MainPage.WebParts.Cast<System.Web.UI.WebControls.WebParts.WebPart>()
                              where wp.GetType() == typeof(Webpart1.Webpart1)
                              select wp;
                if (linqqry.Count() == 0)
                {
                    //Create an instance of WPMenu Webpart and add in a Webpart zone
                    Webpart1.Webpart1 wpWebPart = new Webpart1.Webpart1();
                    MainPage.AddWebPart(wpWebPart, "Main", 0);
                    MainPage.SaveChanges(wpWebPart);
                }
                }
                catch (Exception ex)
                {
                }
        }
   
