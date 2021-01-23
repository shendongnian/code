        public static void PdfToJpg()
        {
            var Thread = new Thread(PdfToJpgThread);
            Thread.SetApartmentState(ApartmentState.STA);
            Thread.Start(); // You can pass your custom data through Start if you need
        }
        private static readonly object PdfToJpgLock = new object();
        private static void PdfToJpgThread(object Data)
        {
            lock (PdfToJpgLock)
            {
                for (int i = 0; i < count; i++)
                {
                    // Call to Acrobat CopyToClipboard
                    // ...
                    Clipboard.GetImage().Save(outputPath, ImageFormat.Jpeg);
                    Clipboard.Clear();
                    // ...
                }
            }
        }
