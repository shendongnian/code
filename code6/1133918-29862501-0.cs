    // define your context
    using (UploadContextDataContext ctx = new UploadContextDataContext())
    {
        try
        {
            // create your new upload
            upload up = new upload();
            up.UploadName = "Some test name";
            // define two new upload files 
            UploadFile file1 = new UploadFile { FileName = "TestFile1.zip" };
            UploadFile file2 = new UploadFile { FileName = "TestFile2.zip" };
            // *ADD* those two new upload files to the "Upload"
            up.UploadFiles.Add(file1);
            up.UploadFiles.Add(file2);
            // define three new upload tags
            UploadTag tag = new UploadTag { TagName = "Tag #1" };
            UploadTag tag2 = new UploadTag { TagName = "Tag #2" };
            UploadTag tag3 = new UploadTag { TagName = "Tag #3" };
            // *ADD* those three new upload tags to the "Upload"
            up.UploadTags.Add(tag);
            up.UploadTags.Add(tag2);
            up.UploadTags.Add(tag3);
            // add the "Upload" to the context - this *INCLUDES* the files and tags!
            ctx.uploads.InsertOnSubmit(up);
            // call SubmitChanges *just once* to store everything!
            ctx.SubmitChanges();
        }
        catch (Exception exc)
        {
            string msg = exc.GetType().Name + ": " + exc.Message;
        }
