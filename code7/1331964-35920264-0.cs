    private void startChecking()
     {
        while (status)
        {
           try
           {
              Process[] processes = Process.GetProcessesByName("notepad");
              UpdateListView("Notepad Count " + processes.Count());
              Thread.Sleep(2000);
           }
           catch (Exception ex)
           {
              MessageBox.Show("Somethine went wrong : " + ex.ToString());
              status = false;
            }
         }
    }
    private void UpdateListView(string message)
    {
        if (listView1.InvokeRequired)
        {
           Action action = () => UpdateListView(message);
           Invoke(action);
        }
        else
        {
          listView1.Items.Clear(); // Clearing the List view before adding them again
          var listViewItem = new ListViewItem(message);
          listView1.Items.Add(listViewItem);
        }
     }
