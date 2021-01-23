        Boolean selChanged = false;
        private void func()
        {
            if (selChanged)
            {
                selChanged = false;
                //do stuff here
            }
        }
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            func();
        }
        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            func();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selChanged = true;
        }
