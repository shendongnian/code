    public void RemoveFromClientList(string ClientName)
    {
        ListViewItem listviewitem = new ListViewItem();
        listviewitem .Name = ClientName;
        if (InvokeRequired)
        {
            Invoke((MethodInvoker)delegate() { listView1.Items.Remove(listviewitem ); });
        }
        else{
                listView1.Items.Remove(listviewitem );
        }
    }
