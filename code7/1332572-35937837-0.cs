    private void removeBtn_Click(object sender, EventArgs e)
        {
            List<string> items = csrListBox.Items.Cast<string>().ToList();
            foreach (string item in csrListBox.Items)
            {
                Regex regex = new Regex(@"^" + domainListBox.SelectedItem + @"\w*");
                Match match = regex.Match(item);
                if (match.Success)
                {
                    items.Remove(item);
                }
            }
            csrListBox.DataSource = items;
        }
