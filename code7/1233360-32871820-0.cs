    void WriteToBrowser(byte[] theData)
    {
        Response.ContentType = "Application/pdf"; // or whatever is right for your data
        Response.OutputStream.Write(theData, 0, theData.Length);
        Response.End();
    }
