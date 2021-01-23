        class ListViewItemComparer : IComparer
        {
            private int col;
            private SortOrder order;
            public ListViewItemComparer()
            {
                col = 0;
                order = SortOrder.Ascending;
            }
            public ListViewItemComparer(int column, SortOrder order)
            {
                col = column;
                this.order = order;
            }
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                decimal value1;
                Decimal.TryParse(((ListViewItem)x).SubItems[col].Text,
                                 System.Globalization.NumberStyles.Currency,
                                 System.Globalization.CultureInfo.CurrentUICulture, 
                                 out value1);
                decimal value2;
                Decimal.TryParse(((ListViewItem)y).SubItems[col].Text,
                                 System.Globalization.NumberStyles.Currency, 
                                 System.Globalization.CultureInfo.CurrentUICulture, 
                                 out value2);
                returnVal = Decimal.Compare(value1, value2);
                // Determine whether the sort order is descending.
                if (order == SortOrder.Descending)
                    // Invert the value returned by String.Compare.
                    returnVal *= -1;
                return returnVal;
            }
        }
