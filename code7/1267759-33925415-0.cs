        private static Key lastKey;
        private static int lastFoundIndex = 0;
        public static void AccountsDataGrid_SearchByKey(object sender, KeyEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if ((dataGrid.Items.Count == 0) && !(e.Key >= Key.A && e.Key <= Key.Z))
            {
                return;
            }
            if ((lastKey != e.Key) || (lastFoundIndex == dataGrid.Items.Count - 1))
            {
                lastFoundIndex = 0;
            }
            for (int i = lastFoundIndex; i < dataGrid.Items.Count; i++)
            {
                if ((lastFoundIndex > 0) && (lastFoundIndex == i))
                {
                    lastFoundIndex = 0;
                }
                if (dataGrid.SelectedIndex == i)
                {
                    continue;
                }
                Account account = dataGrid.Items[i] as Account;
                if (account.Username.StartsWith(e.Key.ToString(), true, CultureInfo.CurrentCulture))
                {
                    dataGrid.ScrollIntoView(account);
                    dataGrid.SelectedItem = account;
                    lastFoundIndex = i;
                    break;
                }
            }
            lastKey = e.Key;
        }
