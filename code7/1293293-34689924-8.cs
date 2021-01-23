                GridView view = (GridView)LstView.View;
                GridViewColumnHeader colHeader = new GridViewColumnHeader() { Content = "Name" };
                colHeader.Click += colHeader_Click;
                view.Columns.Add(new GridViewColumn()
                {
                    DisplayMemberBinding = new Binding("Name"),
                    Header = colHeader
                });
