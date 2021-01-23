    ListViewHitTestInfo lstHitTestInfo = listView1.HitTest(e.X, e.Y);
                    if (e.Button == MouseButtons.Right)
                    {
                        if (lstHitTestInfo.Item != null)
                        {
                            listView1.ContextMenuStrip = contextMenuStrip1;
                        }
                    }
