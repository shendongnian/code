    foreach (var item in batchInspections
                .Select(b => new 
                             {
                                 First = b.FirstOrDefault(),
                                 Count = b.Count(),
                                 Sum = b.Sum(s => s.Duration)
                             } )
                .ToList())
    {
        var bigi = new BatchInspectionGridItem();
        if (item.Any())
        {
            bigi.BatchInspectionNo = item.First.InspectionBatchNo;
            if (item.First.EquipmentTypeID != null)
            {
                bigi.EquipmentTypeName = item.First.EquipmentType.Description;
            }
            else if (item.First.InspectionEquipmentTypes.Any())
            {
                bigi.EquipmentTypeName = string.Join(" / ", item.First.InspectionEquipmentTypes.Select(s => s.EquipmentType.Description));
            }
            bigi.CustomerName = item.First.CustomerSite.Customer.CustomerName;
            bigi.CustomerID = item.First.CustomerSite.Customer.CustomerID;
            bigi.NumberOfInspections = item.Count;
            bigi.TotalDuration = item.Sum;
        }
        viewModel.BatchInspectionGridViewModel.Add(bigi);
    }
