    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        var vstodocument = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.Documents.Add());
        vstodocument.Paragraphs[1].Range.InsertParagraphBefore();
        PictureContentControl picture = vstodocument.Controls.AddPictureContentControl(vstodocument.Paragraphs[1].Range, "pictureControl2");
        picture.LockContents = false;
        picture.Title = "Title";
        picture.Tag = "Tag";
        try
        {
            // Before running put picture.bmp in C:\Users\<user>\Pictures
            string imagePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\picture.bmp";
            System.Drawing.Bitmap bitmap1 = new System.Drawing.Bitmap(imagePath, true);
            picture.Image = bitmap1;
         }
         catch (Exception ex)
         {
             System.Windows.Forms.MessageBox.Show(ex.Message);
         }
     }
