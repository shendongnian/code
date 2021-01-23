    public class RecentFileMenuItem:ToolStripMenuItem
    {
        private string filename; // holds your path+file
        // constructur
        public RecentFileMenuItem(string filename)
            :base(Path.GetFileName(filename))
        {
            // keep our filename
            this.filename = filename;
        }
        // event delegate, subscribe to this
        public RecentEventHandler Recent;
        
        // click invokes all subscribers 
        // for the Recent Event
        protected override void OnClick(EventArgs e)
        {
            RecentEventHandler recent = Recent;
            if (recent !=null)
            {
                // create your RecentEventArgs here
                recent(this, new RecentEventArgs { FileName = filename });
            }
        }
    }
