    // Instantiate the reader
    using (ExifReader reader = new ExifReader(@"C:\temp\testImage.jpg"))
    {
        // Extract the tag data using the ExifTags enumeration
        DateTime datePictureTaken;
        if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out datePictureTaken))
        {
            // Do whatever is required with the extracted information
            MessageBox.Show(this, string.Format("The picture was taken on {0}", 
               datePictureTaken), "Image information", MessageBoxButtons.OK);
        }
    }
