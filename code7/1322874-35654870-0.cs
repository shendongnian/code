        public THINGSelectFlyout()
        {
            this.InitializeComponent();
            foreach (XTHING_IndexItem indexItem in DataStore.Instance.THINGsFoundOnTap)
            {
                Button button = new Button()
                {
                    Name = indexItem.cGuid.ToString("N"),
                    Style = Application.Current.Resources["BigButtons"] as Style
                };
                Grid textGrid = new Grid();
                // Define Grid rows
                RowDefinition rowDef1 = new RowDefinition();
                RowDefinition rowDef2 = new RowDefinition();
                RowDefinition rowDef3 = new RowDefinition();
                rowDef1.Height = new GridLength(20);
                rowDef2.Height = new GridLength(22);
                rowDef3.Height = new GridLength(25);
                textGrid.RowDefinitions.Add(rowDef1);
                textGrid.RowDefinitions.Add(rowDef2);
                textGrid.RowDefinitions.Add(rowDef3);
                // Define Grid columns
                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                colDef1.Width = new GridLength(150);
                colDef2.Width = new GridLength(105);
                textGrid.ColumnDefinitions.Add(colDef1);
                textGrid.ColumnDefinitions.Add(colDef2);
                // Set indexItem text
                TextBlock indexText = new TextBlock();
                indexText.Text = indexItem.cName;
                indexText.TextAlignment = 0;
                textGrid.Children.Add(indexText);
                Grid.SetColumnSpan(indexText, 2);
                Grid.SetRow(indexText, 1);
                // Set assignment text
                TextBlock assgnText = new TextBlock();
                assgnText.Text = "  Assgn: " + indexItem.cAssignedTo;
                indexText.TextAlignment = 0;
                textGrid.Children.Add(assgnText);
                Grid.SetRow(assgnText, 2);
                // Set owner text
                TextBlock ownerText = new TextBlock();
                ownerText.Text = "Owner: " + indexItem.cOwnedBy;
                indexText.TextAlignment = 0;
                textGrid.Children.Add(ownerText);
                Grid.SetRow(ownerText, 2);
                Grid.SetColumn(ownerText, 1);
                button.Content = textGrid;
                button.Click += THINGButton_Click;
                btnList.Items.Add(button);
            }
        }
