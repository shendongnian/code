    using Microsoft.Office.Interop.PowerPoint;
    ...
        private void AddImageWithHyperlink()
        {
            Microsoft.Office.Interop.PowerPoint.Application objApp = new Microsoft.Office.Interop.PowerPoint.Application();
            objApp.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            Presentations objPresSet = objApp.Presentations;
            Presentation objPres = objPresSet.Add(Microsoft.Office.Core.MsoTriState.msoTrue);            
            Slide slide =
                objPres.Slides.Add(
                objPres.Slides.Count + 1,
                PpSlideLayout.ppLayoutPictureWithCaption);
            // Shapes[2] is the image shape on this layout.
            Shape shape = slide.Shapes[2];
            Shape pic = slide.Shapes.AddPicture(@"C:\Users\Public\Pictures\Sample Pictures\koala.jpg",
            Microsoft.Office.Core.MsoTriState.msoFalse,
            Microsoft.Office.Core.MsoTriState.msoTrue,
            shape.Left, shape.Top, shape.Width, shape.Height);
            pic.ActionSettings[PpMouseActivation.ppMouseClick].Hyperlink.Address =@"http://www.google.com/";
        }
