    class FilterCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged
        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                FilterWindow newW = new FilterWindow();
                newW.Owner = Application.Current.MainWindow;
                newW._sender = parameter as DataGrid;
                newW.ShowDialog();//можно через условие нажатия на ок попробовать запилить обработку сохранения или !!!!! смену состояния строк
                if (newW.DialogResult == true)
                {
                    DataGrid dg = parameter as DataGrid;
                    Filters filterList = (Filters)newW.FilterDG.ItemsSource;
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (filterList[i].Visible)
                        {
                            dg.Columns[i].Visibility = Visibility.Visible;
                        }
                        else
                        {
                            dg.Columns[i].Visibility = Visibility.Collapsed;
                        }
                        //тут еще засунуть фильтры!!!
                    }
                }
            }
        }
    }  
