    //The folder that all of our work will be done in
    var workingFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Pdf Test");
    //This is the final PDF that we'll create for testing purposes
    var finalPDF = System.IO.Path.Combine(workingFolder, "test.pdf");
    //Create our working directory if it doesn't exist already
    System.IO.Directory.CreateDirectory(workingFolder);
    //Create sample PDFs and images
    createSampleImages(10, workingFolder);
    createSamplePDFs(10, workingFolder);
    //Create our sample SSRS PDF byte array
    var SSRS_Bytes = getSSRSPdfAsByteArray();
    //This variable will eventually hold our combined PDF as a byte array
    Byte[] finalFileBytes;
    //Write everything to a MemoryStream
    using (var finalFile = new System.IO.MemoryStream()) {
        //Create a generic Document
        using (var doc = new Document()) {
            //Use PdfSmartCopy to intelligently merge files
            using (var copy = new PdfSmartCopy(doc, finalFile)) {
                //Open our document for writing
                doc.Open();
                //#1 - Import the SSRS report
                //Bind a reader to our SSRS report
                using (var reader = new PdfReader(SSRS_Bytes)) {
                    //Loop through each page
                    for (var i = 1; i <= reader.NumberOfPages; i++) {
                        //Add the imported page to our final document
                        copy.AddPage(copy.GetImportedPage(reader, i));
                    }
                }
                
                //#2 - Image the images
                //Loop through each image in our working directory
                foreach (var f in System.IO.Directory.EnumerateFiles(workingFolder, "*.jpg", SearchOption.TopDirectoryOnly)) {
                    //There's different ways to do this and it depends on what exactly "add an image to a PDF" really means
                    //Below we add each individual image to a PDF and then merge that PDF into the main PDF
                    //This could be optimized greatly
                    //From https://alandjackson.wordpress.com/2013/09/27/convert-an-image-to-a-pdf-in-c-using-itextsharp/
                    //Get the size of the current image
                    iTextSharp.text.Rectangle pageSize = null;
                    using (var srcImage = new Bitmap(f)) {
                        pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
                    }
                    //Will eventually hold the PDF with the image as a byte array
                    Byte[] imageBytes;
                    //Simple image to PDF
                    using (var m = new MemoryStream()) {
                        using (var d = new Document(pageSize, 0, 0, 0, 0)) {
                            using (var w = PdfWriter.GetInstance(d, m)) {
                                d.Open();
                                d.Add(iTextSharp.text.Image.GetInstance(f));
                                d.Close();
                            }
                        }
                        //Grab the bytes before closing out the stream
                        imageBytes = m.ToArray();
                    }
                    //Now merge using the same merge code as #1
                    using (var reader = new PdfReader(imageBytes)) {
                        for (var i = 1; i <= reader.NumberOfPages; i++) {
                            copy.AddPage(copy.GetImportedPage(reader, i));
                        }
                    }
                }
                //#3 - Merge additional PDF
                //Look for each PDF in our working directory
                foreach (var f in System.IO.Directory.EnumerateFiles(workingFolder, "*.pdf", SearchOption.TopDirectoryOnly)) {
                    //Because I'm writing samples files to disk but not cleaning up afterwards
                    //I want to avoid adding my output file as an input file
                    if (f == finalPDF) {
                        continue;
                    }
                    //Now merge using the same merge code as #1
                    using (var reader = new PdfReader(f)) {
                        for (var i = 1; i <= reader.NumberOfPages; i++) {
                            copy.AddPage(copy.GetImportedPage(reader, i));
                        }
                    }
                }
                doc.Close();
            }
        }
        //Grab the bytes before closing the stream
        finalFileBytes = finalFile.ToArray();
    }
    //At this point finalFileBytes holds a byte array of a PDF
    //that contains the SSRS PDF, the sample images and the
    //sample PDFs. For demonstration purposes I'm just writing to
    //disk but this could be written to the HTTP stream
    //using Response.BinaryWrite()
    System.IO.File.WriteAllBytes(finalPDF, finalFileBytes);
