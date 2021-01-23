    public void ProcessRequest (HttpContext context) {
        // Get your file as byte[]
        string filename = "....file name.";
        byte[] data = get your PDF file content here;
        
        context.Response.Clear();
                    context.Response.AddHeader("Pragma", "public");
                    context.Response.AddHeader("Expires", "0");
                    context.Response.AddHeader("Content-Type", ContentType);
                    context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filename));
                    context.Response.AddHeader("Content-Transfer-Encoding", "binary");
                    context.Response.AddHeader("Content-Length", data.Length.ToString());
                    context.Response.BinaryWrite(data);
                    context.Response.End(); 
    }
