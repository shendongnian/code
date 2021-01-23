            /// <summary>
            /// This method is used to generate the Bar Code for the Item
            /// </summary>
            private static string GenerateBarCode(string path, string code)
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode(code, BarcodeLib.TYPE.CODE39);
                Image img = b.Encode(BarcodeLib.TYPE.CODE39, code, 300, 50);
                string filename = Guid.NewGuid().ToString() + code + ".png";
                b.SaveImage(HttpContext.Current.Server.MapPath(path + "/" + filename), BarcodeLib.SaveTypes.PNG);
                return filename;
            }
