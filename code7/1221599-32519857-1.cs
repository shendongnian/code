    public class Request
    {
        public static MainForm mainForm = null;
        public static void setLabelText()
        {
            mainForm.diffTime.Text = "Diff:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
