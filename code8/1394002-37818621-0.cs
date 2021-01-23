    private void LogToForm(object line) {
        listView_Log.Invoke(new Action(() =>
        {
            listView_Log.Items.Add(new ListViewItem((string)line));
        });
    }
