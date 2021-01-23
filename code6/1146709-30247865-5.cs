        public static void AddBlockUIContainerImage(this FlowDocument doc, byte[] imageBytes)
        {
            var image2 = Storage.ByteArrayToImage(imageBytes);
            using (var stream = new MemoryStream())
            {
                var subDoc = new FlowDocument();
                subDoc.Blocks.Add(new BlockUIContainer(image2));
                new TextRange(subDoc.ContentStart, subDoc.ContentEnd).Save(stream, DataFormats.XamlPackage, true);
                stream.Seek(0, SeekOrigin.Begin);
                var target = new TextRange(doc.ContentEnd, doc.ContentEnd);
                target.Load(stream, DataFormats.XamlPackage);
            }
        }
