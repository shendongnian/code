    //Create a byte array that will eventually hold our final PDF
    Byte[] bytes;
    //Boilerplate iTextSharp setup here
    //Create a stream that we can write to, in this case a MemoryStream
    using (var ms = new MemoryStream()) {
        //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
        using (var doc = new Document()) {
            //Create a writer that's bound to our PDF abstraction and our stream
            using (var writer = PdfWriter.GetInstance(doc, ms)) {
                //Open the document for writing
                doc.Open();
                //Our sample HTML and CSS
                var example_html = @"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
                var example_css = @".headline{font-size:200%}";
                /**************************************************
                 * Example #1                                     *
                 *                                                *
                 * Use the built-in HTMLWorker to parse the HTML. *
                 * Only inline CSS is supported.                  *
                 * ************************************************/
                //Create a new HTMLWorker bound to our document
                using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc)) {
                    //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
                    using (var sr = new StringReader(example_html)) {
                        //Parse the HTML
                        htmlWorker.Parse(sr);
                    }
                }
                /**************************************************
                 * Example #2                                     *
                 *                                                *
                 * Use the XMLWorker to parse the HTML.           *
                 * Only inline CSS and absolutely linked          *
                 * CSS is supported                               *
                 * ************************************************/
                //XMLWorker also reads from a TextReader and not directly from a string
                using (var srHtml = new StringReader(example_html)) {
                    //Parse the HTML
                    iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                }
                /**************************************************
                 * Example #3                                     *
                 *                                                *
                 * Use the XMLWorker to parse HTML and CSS        *
                 * ************************************************/
                //In order to read CSS as a string we need to switch to a different constructor
                //that takes Streams instead of TextReaders.
                //Below we convert the strings into UTF8 byte array and wrap those in MemoryStreams
                using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css))) {
                    using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_html))) {
                        //Parse the HTML
                        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
                    }
                }
                doc.Close();
            }
        }
        //After all of the PDF "stuff" above is done and closed but **before** we
        //close the MemoryStream, grab all of the active bytes from the stream
        bytes = ms.ToArray();
    }
    //Now we just need to do something with those bytes.
    //Here I'm writing them to disk but if you were in ASP.Net you might Response.BinaryWrite() them.
    //You could also write the bytes to a database in a varbinary() column (but please don't) or you
    //could pass them to another function for further PDF processing.
    var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
    System.IO.File.WriteAllBytes(testFile, bytes);
