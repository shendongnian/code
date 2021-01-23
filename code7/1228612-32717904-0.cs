    public ViewModel(tablegenerateModel tablegenerateModels) //IT WILL BE CALLED WHEN BUTTON WILL BE CLICKED (see tablegenerateModel class ICommand for it)
            {
                tablegenerateModels.Column_data_List = new ObservableCollection<column_Data>();
                for (int i = 1; i < tablegenerateModels.NumberOfColumns; i++)
                {
                    Column_data_List.Add(lb_col = new column_Data()
                    {
                        Column_Name = "ColumnName" + i,
                        Data_Size = i,
                        Data_types = "Double" + i
                    });
                }           
                MessageBox.Show("The NumberOfColumns value is:" + tablegenerateModels.NumberOfColumns);
            }
