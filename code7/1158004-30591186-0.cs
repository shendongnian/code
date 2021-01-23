        public void Test()
        {
            DataGridView view = new DataGridView();
            view.KeyDown += view_KeyDown;
        }
        void view_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter /* && some other conditions */)
            {
                //Do some custom logic
                e.Handled = true; //Cencel event. Avoid any other processing. Like the button was never pressed.
            }
        }
