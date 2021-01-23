    public ActionResult PlayAudio(int id)
    {
        MemoryStream ms = null;
        using (The_FactoryDBContext db = new The_FactoryDBContext())
        {
            if (db.Words.FirstOrDefault(word => word.wordID == id).engAudio != null)
            {
                byte[] bytes = db.Words.FirstOrDefault(word => word.wordID == id).engAudio;
                ms = new MemoryStream(bytes);
            }
        }
        return File(ms,"audio/mpeg");//if it's mp3
    }
