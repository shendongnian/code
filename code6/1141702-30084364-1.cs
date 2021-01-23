    partial class UserControl1 : UserControl
    {
        /* ... */
        public bool IsMyFlagChecked
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        /* ... */
    }
    partial class ParentForm : Form
    {
        /* ... */
        private void SomeMethodThatAddsUserControl1()
        {
            UserControl1 uc1 = new UserControl1;
            uc1.IsMyFlagChecked =
                this.SomeParentFormPropertyUserControl1UsedToReferenceDirectly;
            // other initialization for uc1...
            Controls.Add(uc1);
        }
        /* ... */
    }
