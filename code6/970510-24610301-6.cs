    public ListViewItem GetItemtoDelete(string ClientName )
    {
           ListViewItem listviewitem=new ListViewItem();
           for (int i=0;i<listView1.Items.Count;i++)
            {
                listviewitem=listView1.Items[i];
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
