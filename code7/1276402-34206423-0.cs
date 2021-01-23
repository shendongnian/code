            private void Dgrd_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {         
              if (e.PropertyType == typeof(ObservableCollection<State>))
              {
                  e.Column = new DataGridTemplateColumn() { Header = "StateList", CellTemplate = (DataTemplate)FindResource("CollectionTemplate") };
              }
            }
