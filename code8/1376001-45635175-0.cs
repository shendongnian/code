                    //Load a existing PDF document
                    PdfLoadedDocument ldoc = new PdfLoadedDocument(inputFile);
                    //Create a new PDF compression options
                    PdfCompressionOptions options = new PdfCompressionOptions();
                      
                    //Compress image.
                    options.CompressImages = true;
                    //Set the image quality.
                    options.ImageQuality = 50;
                    //Compress the font data
                    options.OptimizeFont = true;
                    //Compress the page contents
                    options.OptimizePageContents = true;
                    //Remove the metadata information.
                    options.RemoveMetadata = true;
                    //Set the options to loaded PDF document
                    ldoc.CompressionOptions = options;
                    //Save the document
                    ldoc.Save("Output.pdf");
                    //Close the document
                    ldoc.Close(true);
