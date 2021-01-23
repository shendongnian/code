            public class SegmentationShapeProperties
        {
            public Int64 OffsetX { get; set; }
            public Int64 OffsetY { get; set; }
            public Int64 ScaleX { get; set; }
            public Int64 ScaleY { get; set; }
        }   
        public class SegmentationSlideInputData
        {
            public int SlideId { get; set; }
            public OpenXmlUtils.SegmentationShapeProperties ShapeProperties { get; set; }
        }
     public void InsertImages(List<string> imageFilesWithPath, string presentation)
        {
            using (PresentationDocument prstDoc = PresentationDocument.Open(presentation, true))
            {
                PresentationPart presentationPart = prstDoc.PresentationPart;
                var slideParts = OpenXmlUtils.GetSlidePartsInOrder(presentationPart); //gets all the slide parts present in the documetn
                Slide slide = null;
                foreach (string imageWithPath in imageFilesWithPath)
                {
                    SegmentationSlideInputData data = GetWorkingImageDetails(Path.GetFileName(imageWithPath));//function which decides which slide to work on and image scaling options
                    slide = slideParts.ElementAt(data.SlideId).Slide;
                    Picture pic = OpenXmlUtils.AddPicture(slide, imageWithPath, data.ShapeProperties);
                    slide.Save();
                }
                prstDoc.PresentationPart.Presentation.Save();
            }
        }
      private SegmentationSlideInputData GetWorkingImageDetails(string fileName)
        {
            SegmentationSlideInputData data = new SegmentationSlideInputData();
            data.SlideId = 0;//slide id to work on
            data.ShapeProperties = new OpenXmlUtils.SegmentationShapeProperties() { OffsetX = 4695825L, OffsetY = 504825L, ScaleX = 6721828L, ScaleY = 1988495L };//offset specifies the position, scale specifies the height and widht of image
                    break;
            }
            return data;
        }
    internal static P.Picture AddPicture(this Slide slide, string imageFile, SegmentationShapeProperties sP)
        {
            P.Picture picture = new P.Picture();
            string embedId = string.Empty;
            UInt32Value picId = 10001U;
            string name = string.Empty;
            if (slide.Elements<P.Picture>().Count() > 0)
            {
                picId = ++slide.Elements<P.Picture>().ToList().Last().NonVisualPictureProperties.NonVisualDrawingProperties.Id;
            }
            name = "image" + picId.ToString();
            embedId = "rId" + (RandomString(5)).ToString(); // some value
            P.NonVisualPictureProperties nonVisualPictureProperties = new P.NonVisualPictureProperties()
            {
                NonVisualDrawingProperties = new P.NonVisualDrawingProperties() { Name = name, Id = picId, Title = name },
                NonVisualPictureDrawingProperties = new P.NonVisualPictureDrawingProperties() { PictureLocks = new Z.Drawing.PictureLocks() { NoChangeAspect = true } },
                ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties() { UserDrawn = true }
            };
            P.BlipFill blipFill = new P.BlipFill() { Blip = new Z.Drawing.Blip() { Embed = embedId } };
            Z.Drawing.Stretch stretch = new Z.Drawing.Stretch() { FillRectangle = new Z.Drawing.FillRectangle() };
            blipFill.Append(stretch);
            P.ShapeProperties shapeProperties = new P.ShapeProperties()
            {
                Transform2D = new Z.Drawing.Transform2D()
                {
                    //Offset = new Z.Drawing.Offset() { X = 1835696L, Y = 1036712L },
                    //Extents = new Z.Drawing.Extents() { Cx = 5334617, Cy = 1025963 }
                    Offset = new Z.Drawing.Offset() { X = sP.OffsetX, Y = sP.OffsetY },
                    Extents = new Z.Drawing.Extents() { Cx = sP.ScaleX, Cy = sP.ScaleY }
                }
            };
            Z.Drawing.PresetGeometry presetGeometry = new Z.Drawing.PresetGeometry() { Preset = Z.Drawing.ShapeTypeValues.Rectangle };
            Z.Drawing.AdjustValueList adjustValueList = new Z.Drawing.AdjustValueList();
            presetGeometry.Append(adjustValueList);
            shapeProperties.Append(presetGeometry);
            picture.Append(nonVisualPictureProperties);
            picture.Append(blipFill);
            picture.Append(shapeProperties);
            slide.CommonSlideData.ShapeTree.Append(picture);
            // Add Image part
            slide.AddImagePart(embedId, imageFile);
            slide.Save();
            return picture;
        }
    private static void AddImagePart(this Slide slide, string relationshipId, string imageFile)
        {
            ImagePart imgPart = slide.SlidePart.AddImagePart(GetImagePartType(imageFile), relationshipId);
            using (FileStream imgStream = File.Open(imageFile, FileMode.Open))
            {
                imgPart.FeedData(imgStream);
            }
        }
