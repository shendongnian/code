<!-- -->
            TabPage PointedTabPage
            {
                get
                {
                    return TabPages.OfType<TabPage>()
                        .Where((p, tabPageIndex) => GetTabRect(tabPageIndex).Contains(PointToClient(Cursor.Position)))
                        .FirstOrDefault();
                }
            }
        }
    }
