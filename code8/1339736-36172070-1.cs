    private void Page_Load(object sender, EventArgs e)
      {
         page.Response.ContentType = "text/xml";
        // Read XML posted via HTTP
        StreamReader reader = new StreamReader(page.Request.InputStream);
        String xmlData = reader.ReadToEnd(); 
    }
