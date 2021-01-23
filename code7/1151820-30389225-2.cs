    private static void FillPDFForm()
            { 
                    // Original File
                    const string pdfTemplate="Uploads\CV.PDF";
                    // New file which will be created after fillin PDF
                    var newFile ="Uploads\FilledCV.PDF"
                    var pdfReader = new PdfReader(pdfTemplate);
                    var pdfStamper = new PdfStamper(pdfReader, new FileStream(
                        newFile, FileMode.Create));
                    var pdfFormFields = pdfStamper.AcroFields;
                    
                    // So one of our fields in PDF is FullName I am filling it with my full name
                    pdfFormFields.SetField("FullName", "Vuqar Qasimov");                    
    
                    // flatten the form to remove editting options, set it to false
                    // to leave the form open to subsequent manual edits
    
                    pdfStamper.FormFlattening = false;
                    pdfStamper.FormFlattening = false;
                    pdfStamper.Close();
                    break;
                }
    
            }
