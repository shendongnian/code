    [WebMethod]
    public void PlayAudio(int id)
    {
        byte[] bytes = new byte[];
        using (The_FactoryDBContext db = new The_FactoryDBContext())
        {
            if (db.Words.FirstOrDefault(word => word.wordID == id).engAudio != null)
            {
                bytes = db.Words.FirstOrDefault(word => word.wordID == id).engAudio;
            }
        }
        Response.Clear();
        Response.ClearHeaders();
        Response.ContentType = "audio/mpeg3";
        Response.AddHeader("Content-Length", bytes.Length.ToString());
        Response.OutputStream.Write(bytes, 0, bytes.Length);
        Response.Flush();
        Response.End();
    }
