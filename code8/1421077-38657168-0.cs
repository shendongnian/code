    public void UpdateTrucks()
    {
        LoadTrucks();
        if (TruckItems.Count != 0)
        {
            foreach (var item in TruckItemsComparison.Except(TruckItems))
            {
                TruckItems.Add(item);
            }
        }
    }
