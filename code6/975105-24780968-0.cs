    void Events_ListChanged(object sender, ListChangedEventArgs e)
    {
         if (dgv.InvokeRequired)
         {
             dgv.Invoke(new UpdateDataGridItemDelegate(this.Events_ListChanged), sender, e);
             return;
         }
         else
         {
             if (e.ListChangedType == ListChangedType.Reset)
             {
                 dgv.DataSource = null;
                 source = new BindingSource(myBindingList, null);
                 dgv.DataSource = source;
             }
             else
                 source.ResetBindings(false);
             lblTotal.Text = myBindingList.Count.ToString();
         }
    }
