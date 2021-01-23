        private void button1_Click(object sender, EventArgs e)
        {
        bool ok = true;
        foreach (Control c in errorProviderDv.ContainerControl.Controls)
        {
            if (c is TabControl)
            {
                foreach (Control t in (c as TabControl).SelectedTab.Controls)
                {
                    MessageBox.Show(t.Name);
                    if (errorProviderDv.GetError(t) != "")
                    {
                        ok = false;
                    }
                }
            }
        }
    }
