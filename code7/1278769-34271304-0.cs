     using (SPSite oSite = new SPSite(sFileURL))
          {
           using (SPWeb oWeb = oSite.OpenWeb())
                {
                 oWeb.AllowUnsafeUpdates = true;
                 SPFile oFile = oWeb.GetFile(sFileURL); 
                 if (oFile == null)
                 {
                 return false;
                 }
                 SPListItem item = oFile.GetListItem();           
                 if (item.File.Level == SPFileLevel.Checkout)
                 {
                     item.File.UndoCheckOut();
                 }
                 if (item.File.Level != SPFileLevel.Checkout)
                 {
                 item.File.CheckOut();
                 }
        
                 item["Your Column name"] = "Value";
    
                 item.SystemUpdate(false);
                 item.File.CheckIn("SystemCheckedin");
                 item.File.Publish("SystemPublished");    
                 oWeb.AllowUnsafeUpdates = false;
           }
       }
