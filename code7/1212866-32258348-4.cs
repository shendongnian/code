    [WebMethod]
    public void PlayAudio(int id)
    {
        byte[] bytes = new byte[0];
        using (The_FactoryDBContext db = new The_FactoryDBContext())
        {
            if (db.Words.FirstOrDefault(word => word.wordID == id).engAudio != null)
            {
                bytes = db.Words.FirstOrDefault(word => word.wordID == id).engAudio;
            }
        }
        Context.Response.Clear();
        Context.Response.ClearHeaders();
        Context.Response.ContentType = "audio/mpeg";
        Context.Response.AddHeader("Content-Length", bytes.Length.ToString());
        Context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        Context.Response.End();
    }
