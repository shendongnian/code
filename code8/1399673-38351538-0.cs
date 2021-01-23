    using System;
    using System.Windows.Forms;
    public class MyControl : UserControl
    {
        private Button addButton;
        public Button AddButton
        {
            get { return addButton; }
            set
            {
                if (addButton != null)
                    addButton.Click -= new EventHandler(addButton_Click);
                addButton = value;
                if (addButton != null)
                    addButton.Click += new EventHandler(addButton_Click);
            }
        }
        void addButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Button Clicked!");
        }
    }
