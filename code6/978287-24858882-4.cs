      public void fill_checkboxlist()
      {
            host_listbox.Items.Clear();
            host_listbox.BeginUpdate();
            host_listbox.Items.Add("A", false);
            host_listbox.Items.Add("B", false);
            host_listbox.Items.Add("C", false);
            host_listbox.EndUpdate();
      }
