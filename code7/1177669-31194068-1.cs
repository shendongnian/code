    for (int i = 0; i < AllColumnDisplayNames.Length; i++)
                    {
                        // create a new column depending on the data to be displayed
                        DataGridTextColumn col = new DataGridTextColumn();
                        col.MaxWidth = 300;
    
                        /// create a new context menu 
                        ContextMenu menu = new ContextMenu();
    
                        // build the context menu depending on the property
                        menu.Items.Add(new Button() { Content = "FOOBAR" });
    
                        // create a new column's header and add it to the column
                        DataGridColumnHeader head = new DataGridColumnHeader() { Content = AllColumnBindings[i] };
                        head.ContextMenu = menu;//add context menu to DataGridColumnHeader
                        col.Header = head;
    
                        // add the bindings to the data
                        col.Binding = new Binding(AllColumnBindings[i]);
    
                        AllColumns.Add(AllColumnDisplayNames[i], col);
                    }
