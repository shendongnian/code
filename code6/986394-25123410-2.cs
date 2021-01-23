        private List<Registro> _selected = new List<Registry>();
        private void Distribution_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null) return;
            _selected.Clear();
            _selected.AddRange(dg.SelectedItems.Cast<Registry>());
        }
