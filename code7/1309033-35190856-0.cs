     // Get all col widths, set appropriate '*' sizes.
            foreach (ColumnDefinition col in LayoutRoot.ColumnDefinitions)
            {
                colWidths.Add(col.Width);
                total += col.Width.Value;
                Debug.WriteLine($" Width : {col.Width}");
            }
            Debug.WriteLine($"{total}");
            for (int i = 0; i < LayoutRoot.ColumnDefinitions.Count; i++)
            {
                double d = colWidths[i].Value;
                double ratio = d / total;
                int ii = (int) (ratio * 100);
                LayoutRoot.ColumnDefinitions[i].Width = new GridLength(ii, GridUnitType.Star);
            }
