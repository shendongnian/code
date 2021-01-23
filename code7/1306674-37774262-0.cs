    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Drawing;
    using WIA;
    namespace TESTSCAN
    {
        class WIAScanner
        {
            const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
            const string WIA_DEVICE_PROPERTY_PAGES_ID = "3096";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
            const string WIA_SCAN_COLOR_MODE = "6146";
            class WIA_DPS_DOCUMENT_HANDLING_SELECT
            {
                public const uint FEEDER = 0x00000001;
                public const uint FLATBED = 0x00000002;
            }
            class WIA_DPS_DOCUMENT_HANDLING_STATUS
            {
                public const uint FEED_READY = 0x00000001;
            }
            class WIA_PROPERTIES
            {
                public const uint WIA_RESERVED_FOR_NEW_PROPS = 1024;
                public const uint WIA_DIP_FIRST = 2;
                public const uint WIA_DPA_FIRST = WIA_DIP_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
                public const uint WIA_DPC_FIRST = WIA_DPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
                //
                // Scanner only device properties (DPS)
                //
                public const uint WIA_DPS_FIRST = WIA_DPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
                public const uint WIA_DPS_DOCUMENT_HANDLING_STATUS = WIA_DPS_FIRST + 13;
                public const uint WIA_DPS_DOCUMENT_HANDLING_SELECT = WIA_DPS_FIRST + 14;
                
            }
            //public void SetProperty(Property property, int value)
            //{
            //    IProperty x = (IProperty)property;
            //    Object val = value;
            //    x.set_Value(ref val);
            //}
    
            /// <summary>
            /// Use scanner to scan an image (with user selecting the scanner from a dialog).
            /// </summary>
            /// <returns>Scanned images.</returns>
            public static List<Image> Scan()
            {
                WIA.ICommonDialog dialog = new WIA.CommonDialog();
                WIA.Device device = dialog.ShowSelectDevice(WIA.WiaDeviceType.UnspecifiedDeviceType, true, false);
                if (device != null)
                {
                    
                    return Scan(device.DeviceID,1);
                }
                else
                {
                    throw new Exception("You must select a device for scanning.");
                }
            }
    
            /// <summary>
            /// Use scanner to scan an image (scanner is selected by its unique id).
            /// </summary>
            /// <param name="scannerName"></param>
            /// <returns>Scanned images.</returns>
            public static List<Image> Scan(string scannerId, int pages)
            {
                List<Image> images = new List<Image>();
                bool hasMorePages = true;
                int numbrPages = pages;
                while (hasMorePages)
                {
                    // select the correct scanner using the provided scannerId parameter
                    WIA.DeviceManager manager = new WIA.DeviceManager();
                    WIA.Device device = null;
                    foreach (WIA.DeviceInfo info in manager.DeviceInfos)
                    {
                        if (info.DeviceID == scannerId)
                        {
                            // connect to scanner
                            device = info.Connect();
                            break;
                        }
                    }
                    // device was not found
                    if (device == null)
                    {
                        // enumerate available devices
                        string availableDevices = "";
                        foreach (WIA.DeviceInfo info in manager.DeviceInfos)
                        {
                            availableDevices += info.DeviceID + "\n";
                        }
    
                        // show error with available devices
                        throw new Exception("The device with provided ID could not be found. Available Devices:\n" + availableDevices);
                    }
                    SetWIAProperty(device.Properties, WIA_DEVICE_PROPERTY_PAGES_ID, 1);
                    WIA.Item item = device.Items[1] as WIA.Item;
                    AdjustScannerSettings(item, 150, 0, 0, 1250, 1700, 0, 0, 1);
                    try
                    {
                        // scan image
                        WIA.ICommonDialog wiaCommonDialog = new WIA.CommonDialog();
                        WIA.ImageFile image = (WIA.ImageFile)wiaCommonDialog.ShowTransfer(item, wiaFormatBMP, false);
    
                        // save to temp file
                        string fileName = Path.GetTempFileName();
                        File.Delete(fileName);
                        image.SaveFile(fileName);
                        image = null;
                        // add file to output list
                        images.Add(Image.FromFile(fileName));
                    }
                    catch (Exception exc)
                    {
                        throw exc;
                    }
                    finally
                    {
                        item = null;
                        //determine if there are any more pages waiting
                        WIA.Property documentHandlingSelect = null;
                        WIA.Property documentHandlingStatus = null;
                        foreach (WIA.Property prop in device.Properties)
                        {
                            if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_SELECT)
                                documentHandlingSelect = prop;
                            if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_STATUS)
                                documentHandlingStatus = prop;
                        }
                        // assume there are no more pages
                        hasMorePages = false;
                        // may not exist on flatbed scanner but required for feeder
                        if (documentHandlingSelect != null)
                        {
                            // check for document feeder
                            if ((Convert.ToUInt32(documentHandlingSelect.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER) != 0)
                            {
                                hasMorePages = ((Convert.ToUInt32(documentHandlingStatus.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_STATUS.FEED_READY) != 0);
                            }
                        }
                    }
                    numbrPages -= 1;
                    if (numbrPages > 0)
                        hasMorePages = true;
                    else
                        hasMorePages = false;
    
                }
                return images;
            }
            /// <summary>
            /// Gets the list of available WIA devices.
            /// </summary>
            /// <returns></returns>
            public static List<string> GetDevices()
            {
                List<string> devices = new List<string>();
                WIA.DeviceManager manager = new WIA.DeviceManager();
                foreach (WIA.DeviceInfo info in manager.DeviceInfos)
                {
                    devices.Add(info.DeviceID);
                }
                return devices;
            }
            private static void SetWIAProperty(WIA.IProperties properties,
                   object propName, object propValue)
            {
                WIA.Property prop = properties.get_Item(ref propName);
                prop.set_Value(ref propValue);
            }
            private static void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel,
             int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents, int colorMode)
            {
                const string WIA_SCAN_COLOR_MODE = "6146";
                const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
                const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
                const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
                const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
                const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
                const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
                const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
                const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
    
                SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
                SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
                SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
                SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
                SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);
                SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);
                SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);
                SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);
                SetWIAProperty(scannnerItem.Properties, WIA_SCAN_COLOR_MODE, colorMode);
            }
    
        }
    }
