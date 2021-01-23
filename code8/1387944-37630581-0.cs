    foreach (Book b in Program.ListBooks)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = k.IdBook.ToString();
                    lvi.SubItems.Add(k.Author);
                    lvi.SubItems.Add(k.Title);
                    lvi.SubItems.Add(k.Year.ToString());
                    listViewBooks.Items.Add(lvi);
                }
