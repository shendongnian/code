     CarDealer carDealer = GetDealerCars();
     foreach (var groupedCar in carDealer.cars.GroupBy(x => x.carBrand).ToList())
     {
         TreeViewItem item = new TreeViewItem();
         item.Header = groupedCar.Key; 
         var src = new List<Cars>(groupedCar);
         item.ItemTemplate = (DataTemplate)FindResource("subItems");
         item.ItemsSource = src;
          treeView1.Items.Add(item);
     }
