         try
         {
            // Create a DeviceManager instance
            var deviceManager = new DeviceManager();
            List<Image> ret = new List<Image>();
            WIA.CommonDialog dialog = new WIA.CommonDialog();
            WIA.Device device = dialog.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType);
            WIA.Items items = dialog.ShowSelectItems(device);
            foreach (WIA.Item item in items)
            {
               while (true)
               {
                  try
                  {
                     WIA.ImageFile image = (WIA.ImageFile) dialog.ShowTransfer(item);
                     if (image != null && image.FileData != null)
                     {
                        var imageBytes = (byte[]) image.FileData.get_BinaryData();
                        var ms = new MemoryStream(imageBytes);
                        Image img = null;
                        img = Image.FromStream(ms);
                        ret.Add(img);
                     }
                  }
                  catch
                  {
                     break;
                  }
               }
            }
            return ret;
         }
         catch (Exception)
         {
            return null;
         }
