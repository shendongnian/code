    private void PageRankReturns(string Status, FileDownloader f)
    {
                if (listviewUrl.InvokeRequired)
                {
                    delSetStatus s = new delSetStatus(PageRankReturns);
                    this.Invoke(s, new object[] { Status, f });
                }
                else
                {
                    foreach (ListViewItem item in listviewUrl.Items)
                    {
                        if (item.Tag == f)
                        {
                            /* Use locking to synchronise across mutilple thread calls. */
                            lock (_lockObject)
                            {
                                item.SubItems[2].Text = Status;
                            }
                            break;
                        }
                    }
                }
    }
