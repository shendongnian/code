        public MainWindow()
        {
            InitializeComponent();
            Dictionary<double, string> scores = new Dictionary<double, string>();
            scores.Add(1, "the same");
            scores.Add(3, "moderate superiority");
            scores.Add(5, "strong superiority");
            scores.Add(7, "very strong superiority");
            scores.Add(9, "extremely superiority");
            
            //define number of alternatives
            int num = 3;//Alternatives.Children.Count - 1;
            //initialize matrix for assessment scores
            for (int i = 0; i < num; i++)
            {
                gridAssessment.Add(new double[num]);
            }
            //set initial values
            for (int i = 0; i < num; i++)
            {
                gridAssessment[i][i] = scores.ElementAt(0).Key;
            }
            //define source for assessment grid
            grAssessment.ItemsSource = gridAssessment;
            grAssessment.AutoGenerateColumns = false;
            //add columns to the grid
            for (int i = 0; i < num; i++)
            {
                DataGridComboBoxColumn col = new DataGridComboBoxColumn();
                grAssessment.Columns.Add(col);
                col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                //define source for comboboxes
                col.ItemsSource = scores;
                col.DisplayMemberPath = "Value";
                col.SelectedValuePath = "Key";
                string a = "[" + i.ToString() + "]";
                Binding t = new Binding(a);
                t.Mode = BindingMode.TwoWay;
                t.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                col.SelectedValueBinding = t;
            } 
          
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder str1 = new StringBuilder();
            
            foreach (var c in gridAssessment)
            {
                str1.Append("<");
                foreach (var item in c)
                {
                    str1.AppendFormat(" {0} ", item);    
                }
                str1.Append(">");
            }
            val.Content = str1.ToString();
        }
