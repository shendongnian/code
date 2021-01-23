    //At the end of this bytes will hold a byte array representing an actual PDF file
    Byte[] bytes;
    //Create a simple in-memory stream
    using (var ms = new MemoryStream()){
        using (var doc = new Document()) {
            //Create a new PdfWriter bound to our document and the stream
            using (var writer = PdfWriter.GetInstance(doc, ms)) {
                doc.Open();
                //This is unchanged from the OP's code
                //Sample HTML
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"<p>This is a test: <strong>مسندم</strong></p>");
                //Path to our font
                string arialuniTff = Server.MapPath("~/tradbdo.TTF");
                //Register the font with iTextSharp
                iTextSharp.text.FontFactory.Register(arialuniTff);
                //Create a new stylesheet
                iTextSharp.text.html.simpleparser.StyleSheet ST = new iTextSharp.text.html.simpleparser.StyleSheet();
                //Set the default body font to our registered font's internal name
                ST.LoadTagStyle(HtmlTags.BODY, HtmlTags.FACE, "Traditional Arabic Bold");
                //Set the default encoding to support Unicode characters
                ST.LoadTagStyle(HtmlTags.BODY, HtmlTags.ENCODING, BaseFont.IDENTITY_H);
                //Parse our HTML using the stylesheet created above
                List<IElement> list = HTMLWorker.ParseToList(new StringReader(stringBuilder.ToString()), ST);
                //Loop through each element, don't bother wrapping in P tags
                foreach (var element in list) {
                    doc.Add(element);
                }
                doc.Close();
            }
        }
        //Right before closing the MemoryStream grab all of the active bytes
        bytes = ms.ToArray();
    }
    //We now have a valid PDF and can do whatever we want with it
    //In this case, use BinaryWrite to send it directly to the requesting client
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
    Response.BinaryWrite(bytes);
    Response.End();
