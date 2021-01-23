    public class ProjectOneClass
    {
        public event EventHandler UpdateUIEvent;
    
        // other stuff     
        protected override void ResetProperties()
        {
            this.filePath = string.Empty;
            EventArgs e = new EventArgs();
            var handler = UpdateUIEvent;
            if (handler != null)
                UpdateUIEvent(this, e);
        }
    }
