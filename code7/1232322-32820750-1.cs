    public class MdiParent : Form
    {
        private static MdiParent _instance; 
        public static MdiParent Instance
        {
            get { return _instance ?? (_instance = new MdiParent()); }
        }
    }
