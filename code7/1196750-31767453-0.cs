        private void dgdLoadTable_Loaded(object sender, RoutedEventArgs e)
        {
            loadTable = new ObservableCollection<PedLoad>();
            loadTable.Add(new PedLoad { LoadCase = "Dead (D)" });
            loadTable.Add(new PedLoad { LoadCase = "Live (L)" });
            loadTable.Add(new PedLoad { LoadCase = "Roof Live (Lr)" });
            loadTable.Add(new PedLoad { LoadCase = "Snow (S)" });
            loadTable.Add(new PedLoad { LoadCase = "Wind (W)" });
            loadTable.Add(new PedLoad { LoadCase = "Seismic (E)" });
            dgdLoadTable.ItemsSource = loadTable;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            loadTable.Add(new PedLoad { LoadCase = "New Item" });
        }
