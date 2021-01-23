            var myDataTemplate = new DataTemplate(() =>
            {
                var cell = new ViewCell();
                var grid = new Grid();
                foreach (var record in myRecords)
                {
                    grid.RowDefinitions.Add(new RowDefinition());
                }
                foreach (var field in myFields)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                }
                /*
                 * 
                 * Populate grid here...
                 * 
                 */
                cell.View = grid;
                return cell;
            });
