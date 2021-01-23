    private void getListbox(ListBox listBox, string query, string tabelle)
    {
                DataTable table = ru.getDataTable(query);
    
                listBox.DataSource = table;
                listBox.ValueMember = tabelle + "ID";
                listBox.DisplayMember = tabelle;
    }
