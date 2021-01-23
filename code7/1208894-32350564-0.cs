        //This isn't necessery if you know the Part Type (e.g. MainDocumentPart.AddImagePart())
        private static ImagePart CreateImagePart(OpenXmlPart container, string contentType)
        {
            var method = container.GetType().GetMethod("AddImagePart", new Type[] { typeof(string) });
            if (method == null)
                throw new Exception("Can't add an image to type: " + container.GetType().Name);
            return (ImagePart)method.Invoke(container, new object[] { contentType });
        }
        private static string AddImageToDocument(OpenXmlPart part, string imageSource, string contentType, bool addAsLink)
        {
            if (addAsLink)
            {
                ImagePart imagePart = CreateImagePart(part, contentType);
                string id = part.GetIdOfPart(imagePart);
                part.DeletePart(imagePart);
                part.AddExternalRelationship(imagePart.RelationshipType, new Uri(imageSource, UriKind.Absolute), id);
                return id;
            }
            else
            {
                ImagePart imagePart = CreateImagePart(part, contentType);
                using (Stream imageStream = File.Open(imageSource, FileMode.Open))
                {
                    imagePart.FeedData(imageStream);
                }
                return part.GetIdOfPart(imagePart);
            }
        }
