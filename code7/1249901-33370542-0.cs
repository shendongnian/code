        private static BlockUIContainer ConvertBinaryToImageUIContainer(string binary)
        {
            byte[] binaryData = Convert.FromBase64String(binary);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(binaryData);
            bitmapImage.EndInit();
            BlockUIContainer container = new BlockUIContainer();
            container.Child = new System.Windows.Controls.Image { Source = bitmapImage };
            return container;
        }
