	var Data = (from r in _context.PRD_ChemProdReq
               orderby r.RequisitionNo descending
               select new PRDChemProdReq
               {
                   // do your initialization
               });
    var subsetOfData = Data.Take(100).ToList(); // Now it's loaded to memory
    foreach (var item in subsetOfData)
    {
        item.RequisitionCategory = DalCommon.ReturnRequisitionCategory(item.RequisitionCategory);
        item.RequisitionType = DalCommon.ReturnOrderType(item.RequisitionType);
        item.ReqRaisedOn = (Convert.ToDateTime(item.ReqRaisedOnTemp)).ToString("dd'/'MM'/'yyyy");
        item.RecordStatus = DalCommon.ReturnRecordStatus(item.RecordStatus);
        item.RequisitionFromName = DalCommon.GetStoreName(item.RequisitionFrom);
        item.RequisitionToName = DalCommon.GetStoreName(item.RequisitionTo);
    }
