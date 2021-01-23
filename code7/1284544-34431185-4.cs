        ViewModel vm = new ViewModel();
        System.Diagnostics.Debug.WriteLine(vm.ShootingDayInfoList.Count.ToString());
        vm.SelectedDay.Date = DateTime.Parse("12/23/2015");
        
        IEnumerable<ShootingDay> underlyingCollection = ((IEnumerable<ShootingDay>)vm.ShootingDayInfoList.SourceCollection);
        ShootingDay d1 = underlyingCollection.FirstOrDefault(dt => dt.Date.Equals(vm.SelectedDay.Date)); 
        vm.ShootingDayInfoList.MoveCurrentTo(d1); 
