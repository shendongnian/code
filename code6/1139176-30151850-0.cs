     Workbook workbook = new Workbook(@"D:\a.xlsm");
                //Get the first worksheet.
                Worksheet sheet = workbook.Worksheets[12];
    
                //Define ImageOrPrintOptions
                ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();
                //Specify the image format
                imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                //Only one page for the whole sheet would be rendered
                imgOptions.OnePagePerSheet = true;
    
                //Render the sheet with respect to specified image/print options
                SheetRender sr = new SheetRender(sheet, imgOptions);
                //Render the image for the sheet
                Bitmap bitmap = sr.ToImage(0);
    
                //Save the image file specifying its image format.
                bitmap.Save(@"d:\SheetImage.jpg");
