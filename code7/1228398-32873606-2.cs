    WIA.CommonDialog dialog = new WIA.CommonDialog();
            WIA.Device device = dialog.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType);
            WIA.Items items = dialog.ShowSelectItems(device);
            foreach (WIA.Item item in items)
            {
                while (true)
                {
                    WIA.ImageFile image = null;
                    try
                    {
                        dialog = new WIA.CommonDialog();
                        image = (WIA.ImageFile)dialog.ShowTransfer(item,"{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}", false);
                        if (image != null && image.FileData != null)
                        {
                            dynamic binaryData = image.FileData.get_BinaryData();
                            if (binaryData is byte[])
                                using (MemoryStream stream = new MemoryStream(binaryData))
                                using (Bitmap bitmap = (Bitmap) Bitmap.FromStream(stream))
                                {
                                    bitmap.Save(String.Format(@"C:\Temp\scan{0}.jpg", Path.GetRandomFileName()),
                                        ImageFormat.Jpeg);
                                }
                        }
                    }
                    catch (COMException)
                    {
                        break;
                    }
                    finally
                    {
                        if (image != null)
                            Marshal.FinalReleaseComObject(image);
                    }
                }
            }
