            // Add 10 Rows
            for (int i = 0; i < 10; i++)
            {
                var height = GridLength.Auto;
                if (i == 0)
                    height = new GridLength(1, GridUnitType.Star);
                layoutGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = height
                });    
            }
            // Add 7 Columns
            for (int i = 0; i < 7; i++)
            {
                var width = GridLength.Auto;
                if (i == 0)
                    width = new GridLength(1, GridUnitType.Star);
                layoutGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = width
                });
            }
