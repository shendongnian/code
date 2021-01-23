    public ListViewItem GetItemtoDelete(string ClientName )
    {
           foreach (ListViewItem listviewitem in listView1)
            {
                if (ClientName == listviewitem.Text)
                 {
                      return listviewitem;
                 }
            }
           return null;
    }
    public void RemoveFromClientList(string ClientName)
    {
        ListViewItem listviewitem = new ListViewItem();
        listviewitem =GetItemtoDelete(ClientName );
        if(listviewitem !=null)
        {
             if (InvokeRequired)
             {
                   Invoke((MethodInvoker)delegate() { listView1.Items.Remove(listviewitem ); });
             }
             else
             {
                   listView1.Items.Remove(listviewitem );
        }
        }
    }
