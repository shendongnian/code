     //Create Custom Event
        public delegate void DeleteControlDelegate(object sender);
    
        public partial class ComboControl : UserControl
        {
            //Custom Event to send Delete request
            public event DeleteControlDelegate DeleteControlDelegate;
    
            public ComboControl()
            {
                InitializeComponent();
            }
    
            //Invoke Custom Event
            private void OnDeleteControl(object sender)
            {
                DeleteControlDelegate?.Invoke(sender);
            }
    
            private void BtnDel_Click(object sender, EventArgs e)
            {
                //On ButtonClick send Delete request
               OnDeleteControl(this);
            }
        }
