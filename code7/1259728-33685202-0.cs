    // Create a .docx file
    using (DocX document = DocX.Create(@"Example.docx"))
    {
      // Add an Image to the docx file
       Novacode.Image img = document.AddImage(@"Donkey.jpg");
       // Insert an emptyParagraph into this document.
       Paragraph p = document.InsertParagraph("", false);
      #region pic1
      Picture pic1 = p.InsertPicture(img.Id, "Donkey", "Taken on Omey island");
       // Set the Picture pic1’s shape
       pic1.SetPictureShape(BasicShapes.cube);
       // Rotate the Picture pic1 clockwise by 30 degrees
       pic1.Rotation = 30;
        #endregion
       #region pic2
       // Create a Picture. A Picture is a customized view of an Image
       Picture pic2 = p.InsertPicture(img.Id, "Donkey", "Taken on Omey island");
       // Set the Picture pic2’s shape
       pic2.SetPictureShape(CalloutShapes.cloudCallout);
      // Flip the Picture pic2 horizontally
       pic2.FlipHorizontal = true;
       #endregion
       // Save the docx file
       document.Save();
    }// Release this document from memory.
