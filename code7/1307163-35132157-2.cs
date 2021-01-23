    public class Main
    {
        private List<FilterMcode> _qf;
        public void updateDataGrid()
        {
            _qf.ForEach(mcode => mcode.PropertyChanged += McodeOnPropertyChanged);
            DataGridCommands.ItemsSource = _qf;
            DataGridCommands.Items.Refresh();
            // calling check box click????
        }
        private void McodeOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName != "Cb" ) return;
            //Add your logic here
        }
    }
