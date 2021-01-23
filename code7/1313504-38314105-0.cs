    protected void convertToPdfButton_Click(object sender, EventArgs e)
    {
        // Get the server IP and port
        String serverIP = textBoxServerIP.Text;
        uint serverPort = uint.Parse(textBoxServerPort.Text);
    
        // Create a HTML to PDF converter object with default settings
        HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter(serverIP, serverPort);
                
        // Set optional service password
        if (textBoxServicePassword.Text.Length > 0)
            htmlToPdfConverter.ServicePassword = textBoxServicePassword.Text;
    
        // Set HTML Viewer width in pixels which is the equivalent in converter of the browser window width
        htmlToPdfConverter.HtmlViewerWidth = int.Parse(htmlViewerWidthTextBox.Text);
    
        // Set HTML viewer height in pixels to convert the top part of a HTML page 
        // Leave it not set to convert the entire HTML
        if (htmlViewerHeightTextBox.Text.Length > 0)
            htmlToPdfConverter.HtmlViewerHeight = int.Parse(htmlViewerHeightTextBox.Text);
    
        // Set PDF page size which can be a predefined size like A4 or a custom size in points 
        // Leave it not set to have a default A4 PDF page
        htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = SelectedPdfPageSize();
    
        // Set PDF page orientation to Portrait or Landscape
        // Leave it not set to have a default Portrait orientation for PDF page
        htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = SelectedPdfPageOrientation();
    
        // Set the maximum time in seconds to wait for HTML page to be loaded 
        // Leave it not set for a default 60 seconds maximum wait time
        htmlToPdfConverter.NavigationTimeout = int.Parse(navigationTimeoutTextBox.Text);
    
        // Set an adddional delay in seconds to wait for JavaScript or AJAX calls after page load completed
        // Set this property to 0 if you don't need to wait for such asynchcronous operations to finish
        if (conversionDelayTextBox.Text.Length > 0)
            htmlToPdfConverter.ConversionDelay = int.Parse(conversionDelayTextBox.Text);
    
        // The buffer to receive the generated PDF document
        byte[] outPdfBuffer = null;
    
        if (convertUrlRadioButton.Checked)
        {
            string url = urlTextBox.Text;
    
            // Convert the HTML page given by an URL to a PDF document in a memory buffer
            outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);
        }
        else
        {
            string htmlString = htmlStringTextBox.Text;
            string baseUrl = baseUrlTextBox.Text;
    
            // Convert a HTML string with a base URL to a PDF document in a memory buffer
            outPdfBuffer = htmlToPdfConverter.ConvertHtml(htmlString, baseUrl);
        }
    
        // Send the PDF as response to browser
    
        // Set response content type
        Response.AddHeader("Content-Type", "application/pdf");
    
        // Instruct the browser to open the PDF file as an attachment or inline
        Response.AddHeader("Content-Disposition", String.Format("{0}; filename=Getting_Started.pdf; size={1}",
            openInlineCheckBox.Checked ? "inline" : "attachment", outPdfBuffer.Length.ToString()));
    
        // Write the PDF document buffer to HTTP response
        Response.BinaryWrite(outPdfBuffer);
    
        // End the HTTP response and stop the current page processing
        Response.End();
    }
