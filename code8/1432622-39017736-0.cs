    public ActionResult Get([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
    {
    
      IQueryable<asset> query = DbContext.Assets;
      // Sorting
      var sortedColumns = requestModel.Columns.GetSortedColumns();
      var orderByString = String.Empty;
 
      foreach (var column in sortedColumns)
      {
         orderByString += orderByString != String.Empty ? "," : "";
         orderByString += (column.Data) + (column.SortDirection == Column.OrderDirection.Ascendant ? " asc" : " desc");
      }
 
        query = query.OrderBy(orderByString == string.Empty ? "BarCode asc" : orderByString);
       var data = query.Select(asset => new
       {
          AssetID = asset.AssetID,
          BarCode = asset.Barcode,
          Manufacturer = asset.Manufacturer,
          ModelNumber = asset.ModelNumber,
          Building = asset.Building,
          RoomNo = asset.RoomNo,
          Quantity = asset.Quantity
       }).ToList();
 
     return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount), JsonRequestBehavior.AllowGet);
    }
