       public partial class SaveCancelButtons : UserControl
        {
             public delegate void SaveClickedHandler();
              public delegate void CancelClickedHandler();
            public SaveCancelButtons()
            {
                InitializeComponent();
        
            }
        
            public event EventHandler SaveClicked;
            public event EventHandler CancelClicked;
        
            protected virtual void OnSaveClicked()
            {
                EventHandler handler = SaveClicked;
                if (SaveClicked != null)         //
                {
                    handler(this,new EventArgs());  // Notify Subscribers
                }
            }
            protected virtual void OnCancelClicked()
            {
                EventHandler handler = CancelClicked;
                if (CancelClicked != null)       // <<<< 
                {
                    handler(this,new EventArgs());  // Notify Subscribers
                }
            }
        
            private void btnSave_Click(object sender, EventArgs e)
            {
                OnSaveClicked();
            }
        
            private void btnCancel_Click(object sender, EventArgs e)
            {
                OnCancelClicked();
            }
        }
