    ViewModel vm = new ViewModel();
    System.Diagnostics.Debug.WriteLine(vm.ShootingDayInfoList.Count.ToString());
    vm.SelectedDay.Date = DateTime.Parse("12/25/2015");
                    
    vm.ShootingDayInfoList.Filter = (o) =>
    {
        if (((ShootingDay)o).Date.Equals(vm.SelectedDay.Date))
            return true;
    
        return false;
    };
    
    ShootingDay foundItem = (ShootingDay)vm.ShootingDayInfoList.GetItemAt(0);
    vm.ShootingDayInfoList.Filter = (o) => { return true; };
                    
    vm.ShootingDayInfoList.MoveCurrentTo(foundItem); 
