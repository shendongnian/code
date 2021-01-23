     public static void GetImages()
            {
                var doc = PresentationDocument.Open(@"E:\Dev\Stuff\ConsoleApplication1\ConsoleApplication1\bin\Debug\test.pptx", true);
            var presentationPart = doc.PresentationPart;
            foreach (var slide in presentationPart.GetPartsOfType<SlidePart>())
            {
                foreach (var image in slide.GetPartsOfType<ImagePart>())
                {
                    if (image != null)
                    {
                        var stream = image.GetStream();
                       
                        var img = Image.FromStream(stream);
                        img.Save(@"E:\Dev\Stuff\ConsoleApplication1\ConsoleApplication1\bin\Debug\" + System.IO.Path.ChangeExtension(System.IO.Path.GetRandomFileName(), "jpg"));
                    }
                }
            }
        }
