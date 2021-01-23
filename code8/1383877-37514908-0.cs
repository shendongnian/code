            //***  Database Menu Click  ***
            grdExcel.Visibility = Visibility.Hidden;
            grdDatabase.Visibility = Visibility.Visible;
            //grdDataScrubber.Children.Remove(grdExcel);
            // ... Cast sender object.
            MenuItem item = sender as MenuItem;
            // ... Change Title of this window.
            Title = "Process " + item.Header + " Files";
            //InitializeGrid(grdDatabase, item);
            //AddDatabaseControls();
            //grdDataScrubber.Children.Add(grdDatabase);
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //***  Excel Menu Click  ***
            Label lblExcelInfo = new Label();
            grdDatabase.Visibility = Visibility.Hidden;
            grdExcel.Visibility = Visibility.Visible;
            //grdDataScrubber.Children.Remove(grdDatabase);
            // ... Cast sender object.
            MenuItem item = sender as MenuItem;
            // ... Change Title of this window.
            Title = "Process " + item.Header + " Files";
            //InitializeGrid(grdExcel);
            //lblExcelInfo.Content = "In Excel";
            //grdExcel.Children.Add(lblExcelInfo);
            //grdDataScrubber.Children.Add(grdExcel);
        }
        private void InitializeGrid(Grid gridArea)
        {
            gridArea.Height = 330;
            gridArea.Width = 650;
            gridArea.HorizontalAlignment = HorizontalAlignment.Left;
            gridArea.Margin = new Thickness
            {
                Bottom = 0,
                Left = 70,
                Top = 0,
                Right = 0
            };
            gridArea.VerticalAlignment = VerticalAlignment.Top;
            //gridArea.Background = new SolidColorBrush(Color.FromRgb(04, 149, 168));
            grdDataScrubber.Children.Add(gridArea);
        }
        private void AddDatabaseControls()
        {
            int intNumCols = 7;
            int intNumRows = 15;
            int intControlHeight = 20;
            ColumnDefinition[] cols = new ColumnDefinition[intNumCols];
            RowDefinition[] rows = new RowDefinition[intNumRows];
            Label lblGridTitle = new Label();
            Label lblDBInstance = new Label();
            ComboBox cbxDBInstances = new ComboBox();
            Button btnLoadDBInfo = new Button();
            Label lblDBName = new Label();
            ComboBox cbxDBName = new ComboBox();
            Label lblTableName = new Label();
            ComboBox cbxTableName = new ComboBox();
            Label lblOutputName = new Label();
            TextBox txtOutputFolder = new TextBox();
            Button btnBrowseFolder = new Button();
            Button btnSubmit = new Button();
            InitializeDatabaseColumns(intNumCols, cols);
            InitializeDatabaseRows(intNumRows, rows);
            lblGridTitle.Content = "Enter Database Info";
            lblGridTitle.FontFamily = new FontFamily("Arial");
            lblGridTitle.FontSize = 13;
            lblGridTitle.FontWeight = FontWeights.Bold;
            Grid.SetRow(lblGridTitle, 1);
            Grid.SetColumn(lblGridTitle, 1);
            grdDatabase.Children.Add(lblGridTitle);
            lblDBInstance.Content = "Enter Database Instance:";
            lblDBInstance.FontFamily = new FontFamily("Arial");
            lblDBInstance.FontSize = 11;
            lblDBInstance.Height = intControlHeight;
            Grid.SetRow(lblDBInstance, 3);
            Grid.SetColumn(lblDBInstance, 1);
            grdDatabase.Children.Add(lblDBInstance);
            cbxDBInstances.FontFamily = new FontFamily("Arial");
            cbxDBInstances.FontSize = 11;
            cbxDBInstances.Height = intControlHeight;
            Grid.SetRow(cbxDBInstances, 3);
            Grid.SetColumn(cbxDBInstances, 3);
            grdDatabase.Children.Add(cbxDBInstances);
            btnLoadDBInfo.FontFamily = new FontFamily("Arial");
            btnLoadDBInfo.FontSize = 11;
            btnLoadDBInfo.FontWeight = FontWeights.Bold;
            btnLoadDBInfo.Content = "Load DB Info";
            btnLoadDBInfo.Width = 75;
            btnLoadDBInfo.IsEnabled = false;
            btnLoadDBInfo.Click += new RoutedEventHandler(btnLoadDBInfo_Click);
        //    btnLoadDBInfo.Click = new System.EventHandler(btnLoadDBInfo_Click);
            Grid.SetRow(btnLoadDBInfo, 3);
            Grid.SetColumn(btnLoadDBInfo, 5);
            lblDBName.Content = "Choose Database:";
            lblDBName.FontFamily = new FontFamily("Arial");
            lblDBName.FontSize = 11;
            lblDBName.Height = intControlHeight;
            Grid.SetRow(lblDBName, 5);
            Grid.SetColumn(lblDBName, 1);
            grdDatabase.Children.Add(lblDBName);
            cbxDBName.FontFamily = new FontFamily("Arial");
            cbxDBName.FontSize = 11;
            cbxDBName.Height = intControlHeight;
            Grid.SetRow(cbxDBName, 5);
            Grid.SetColumn(cbxDBName, 3);
            grdDatabase.Children.Add(cbxDBName);
            lblTableName.Content = "Choose Database:";
            lblTableName.FontFamily = new FontFamily("Arial");
            lblTableName.FontSize = 11;
            lblTableName.Height = intControlHeight;
            Grid.SetRow(lblTableName, 7);
            Grid.SetColumn(lblTableName, 1);
            grdDatabase.Children.Add(lblTableName);
            cbxTableName.FontFamily = new FontFamily("Arial");
            cbxTableName.FontSize = 11;
            cbxTableName.Height = intControlHeight;
            Grid.SetRow(cbxTableName, 7);
            Grid.SetColumn(cbxTableName, 3);
            grdDatabase.Children.Add(cbxTableName);
            lblOutputName.Content = "Choose Output Folder:";
            lblOutputName.FontFamily = new FontFamily("Arial");
            lblOutputName.FontSize = 11;
            lblOutputName.Height = intControlHeight;
            Grid.SetRow(lblOutputName, 9);
            Grid.SetColumn(lblOutputName, 1);
            grdDatabase.Children.Add(lblOutputName);
            txtOutputFolder.FontFamily = new FontFamily("Arial");
            txtOutputFolder.FontSize = 11;
            txtOutputFolder.Height = intControlHeight;
            Grid.SetRow(txtOutputFolder, 9);
            Grid.SetColumn(txtOutputFolder, 3);
            grdDatabase.Children.Add(txtOutputFolder);
            btnBrowseFolder.FontFamily = new FontFamily("Arial");
            btnBrowseFolder.FontSize = 11;
            btnBrowseFolder.FontWeight = FontWeights.Bold;
            btnBrowseFolder.Content = "Browse...";
            btnBrowseFolder.Width = 60;
            btnBrowseFolder.IsEnabled = false;
            Grid.SetRow(btnBrowseFolder, 9);
            Grid.SetColumn(btnBrowseFolder, 5);
            grdDatabase.Children.Add(btnBrowseFolder);
            btnSubmit.FontFamily = new FontFamily("Arial");
            btnSubmit.FontSize = 11;
            btnSubmit.FontWeight = FontWeights.Bold;
            btnSubmit.Content = "Submit";
            btnSubmit.Width = 50;
            btnSubmit.IsEnabled = false;
            Grid.SetRow(btnSubmit, 11);
            Grid.SetColumn(btnSubmit, 3);
            grdDatabase.Children.Add(btnSubmit);
            grdDatabase.Children.Add(btnLoadDBInfo);
        }
        public void InitializeDatabaseColumns(int intNumCols, ColumnDefinition[] cols)
        {
            for (int i = 0; i < intNumCols; i++)
            {
                cols[i] = new ColumnDefinition();
                grdDatabase.ColumnDefinitions.Add(cols[i]);
            }
            cols[0].Width = new GridLength(15);
            cols[1].Width = new GridLength(150);
            cols[2].Width = new GridLength(10);
            cols[3].Width = new GridLength(200);
            cols[4].Width = new GridLength(10);
            cols[5].Width = new GridLength(200);
            cols[6].Width = new GridLength(30);
        }
        public void InitializeDatabaseRows(int intNumRows, RowDefinition[] rows)
        {
            for (int x = 0; x < intNumRows; x++)
            {
                rows[x] = new RowDefinition();
                grdDatabase.RowDefinitions.Add(rows[x]);
                rows[x].Height = new GridLength(26);
                if (x % 2 == 0)
                {
                    // Setting column width.
                    rows[x].Height = new GridLength(15);
                }
            }
            rows[0].Height = new GridLength(5);
            rows[1].Height = new GridLength(30);
            rows[10].Height = new GridLength(40);
        }
