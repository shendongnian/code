    for (int i = this.superTabControl1.Tabs.Count - 1; i >= 0; i--)
                {
                    BaseItem item = this.superTabControl1.Tabs[i];
                    if (!item.Equals(this.superTabControl1.SelectedTab))
                    {
                        (item as SuperTabItem).Close();
                    }
                }
