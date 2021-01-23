    // Maybe you can even omit AsEnumerable()
    foreach(var row in detailTable.AsEnumerable())
    {                       
        context.LeasingSPReadingDetailEntities.AddObject(
            new LeasingSPReadingDetailEntity()//new entity from datatable
            {
               //SPReadingId = row.Field<long>("ProductID"),
               SPReadingMasterId = masterId,
               BillCycleYear = int.Parse(row.Field<int>("Bill Cycle").ToString().Substring(0, 4)),
               BillCycleMonth = byte.Parse(row.Field<byte>("Bill Cycle").ToString().Substring(4)),
               AccountNumber = row.Field<string>("Account No."),
               PeriodStart = row.Field<DateTime>("Period Start"),
               PeriodEnd = row.Field<DateTime>("Period End"),
               TownCouncil = row.Field<string>("Customer Name"),
               Service = row.Field<string>("Service Type"),
               Adjustment = row.Field<string>("Adjustment"),
               Block = row.Field<string>("Blk"),
               AddressLine1 = row.Field<string>("Adress Line 1"),
               AddressLine2 = row.Field<string>("Adress Line 2"),
               AddressLine3 = row.Field<string>("Postal Code"),
               Usage = row.Field<decimal>("Usage"),
               Rate = row.Field<decimal>("Rate"),
               Amount = row.Field<decimal>("Amount")
            }
        );
    }
