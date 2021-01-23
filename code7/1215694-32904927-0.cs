    public class AudioHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            byte[] bytes = new byte[0];
            using (The_FactoryDBContext db = new The_FactoryDBContext())
            {
                if (db.Words.FirstOrDefault(word => word.wordID == id).engAudio != null)
                {
                    bytes = db.Words.FirstOrDefault(word => word.wordID == id).engAudio;
                    context.Response.ContentType = "audio/wav";
                    context.Response.BinaryWrite(bytes);
                    context.Response.Flush();
                }
            }
        }
    }
