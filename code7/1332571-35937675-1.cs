            string server = serverListBox.SelectedItem as string;
            serverListBox.Remove(server);
            for (int i = domainListBox.Items.Count -1; i >-1; i--)
            {
                if (domainListBox.Items[i].ToString().StartsWith(server))
                {
                    string domain = domainListBox.Items[i].ToString();
                    domainListBox.Items.RemoveAt(i);
                    for (int j = csrListBox.Items.Count-1; j > -1; j--)
                    {
                        if (csrListBox.Items[j].ToString().StartsWith(domain))
                        {
                            csrListBox.Items.RemoveAt(j);
                        }
                    }
                }
            }
