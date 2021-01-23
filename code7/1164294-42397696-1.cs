    var item = context.MyObjects.Find(id);
    item.CurrentDataColumnName = "ChangedCurrentDataColumnName";
    item.HistoricDataColumnName = "ChangedHistoricDataColumnName";
    context.Entry(item).Property(c => c.HistoricDataColumnName).IsModified = false;
    context.SaveChanges();
