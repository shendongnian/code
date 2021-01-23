    var details = detailTable.AsEnumerable().Select(row => new  LeasingSPReadingDetailEntity()//new entity from datatable
             {
                SPReadingId = row.Field<long>("ProductID"),
                SPReadingMasterId = masterId,
                BillCycleYear = int.Parse(row.Field<int>("Bill Cycle").ToString().Substring(0, 4)),
                BillCycleMonth = byte.Parse(row.Field<byte>("Bill Cycle").ToString().Substring(4)),
            }).ToList();
            foreach(var detail  in details)
            {                       
                context.LeasingSPReadingDetailEntities.Add(detail);
            }
