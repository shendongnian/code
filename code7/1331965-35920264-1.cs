    private void startChecking()
     {
        while (status)
        {
           try
           {
              Process[] processes = Process.GetProcessesByName("notepad");
              UpdateListView(processes.Count());
              Thread.Sleep(2000);
           }
           catch (Exception ex)
           {
              MessageBox.Show("Somethine went wrong : " + ex.ToString());
              status = false;
            }
         }
    }
    private void UpdateListView(int processCount)
    {
        if (listView1.InvokeRequired)
        {
           Action action = () => UpdateListView(processCount);
           Invoke(action);
        }
        else
        {
          listView1.Items.Clear(); // Clearing the List view before adding them again
          for (int i = 0; i < processCount; i++)
          {
             ListViewItem accountAdd = new ListViewItem(i.ToString());
             listView1.Items.Add(accountAdd);
          }
        }
     }
