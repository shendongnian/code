      public partial class Form1 : Form
      {
   
        private SimpleDirtyTracker _dirtyTracker;
   
   
        private void Form1_Load(object sender, EventArgs e)
        {
       
          _dirtyTracker = new SimpleDirtyTracker(this);
          _dirtyTracker.SetAsClean();
        }
       private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        // upon closing, check if the form is dirty; if so, prompt
        // to save changes
        if (_dirtyTracker.IsDirty)
        {
            DialogResult result
                = (MessageBox.Show(
                    "Would you like to save changes before closing?"
                    , "Save Changes"
                    , MessageBoxButtons.YesNoCancel
                    , MessageBoxIcon.Question));
         }
   
    }
