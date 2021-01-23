        private void Form1_Load(object sender, EventArgs e)
        {
            fill_checkboxlist(host_listbox);
        }
        public static void fill_checkboxlist(CheckedListBox chlb)
        {
            chlb.Items.Clear();
            chlb.BeginUpdate();
            chlb.Items.Add("A", false);
            chlb.Items.Add("B", false);
            chlb.Items.Add("C", false);
            chlb.EndUpdate();
        }
