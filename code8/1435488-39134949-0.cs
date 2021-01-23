    public class BodyContentsDemo : WebTestRequestPlugin
    {
        public override void PostRequest(object sender, PostRequestEventArgs e)
        {
            byte[] bb = e.Response.BodyBytes;
            string ss = e.Response.BodyString;
            e.WebTest.AddCommentToResult(
                "BodyBytes is " +
                bb == null ? " null"
                : bb.Length.ToString() + " bytes");
            e.WebTest.AddCommentToResult(
                "BodyString is " +
                ss == null ? "null"
                : ss.Length.ToString() + " chars");
            // Use bb or ss.
        }
    }
