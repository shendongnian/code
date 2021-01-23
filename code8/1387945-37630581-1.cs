    foreach (Book b in Program.ListBooks)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = b.IdBook.ToString();
                    lvi.SubItems.Add(b.Author);
                    lvi.SubItems.Add(b.Title);
                    lvi.SubItems.Add(b.Year.ToString());
                    listViewBooks.Items.Add(lvi);
                }
