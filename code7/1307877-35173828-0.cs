     var soiAttr = (from s in ctxParser.TBL_SERVICE_ORDER_ATTRIBUTES_VERSIONING
                           where s.ParentId == parentId
                           select s).ToList();
     var resultJoinCOI = (from iFoi in listFOI
                                 join soaI in soiAttr on
                                 new
                                 {
                                     ServiceOrderNo = iFoi.fulfilmentOrderItemIdentifier,
                                     AttributeId = iFoi.coiId
                                 }
                                 equals new
                                 {
                                     ServiceOrderNo = soaI.ServiceOrderNo,
                                     AttributeId = soaI.AttributeId
                                 }
                                 into res
                                 from subFoi in res.DefaultIfEmpty()
                                 select new
                                 {
                                     fulfilmentOrderItemIdentifier = iFoi.fulfilmentOrderItemIdentifier,
                                     coiId = iFoi.coiId,
                                     coiIdentifier = iFoi.coiIdentifier,
                                     AttributeId = subFoi == null ? 0 : subFoi.AttributeId,
                                     ParentId = subFoi == null ? parentId : subFoi.ParentId,  
                                     ServiceOrderNo = subFoi == null ? string.Empty: subFoi.ServiceOrderNo
                                 });
      if (resultJoinCOI != null)
            {
                if (resultJoinCOI.Count() > 0)
                {
                    var listToInsert = (from item in resultJoinCOI
                                        select new TBL_SERVICE_ORDER_ATTRIBUTES_VERSIONING
                                        {
                                            ServiceOrderNo = item.fulfilmentOrderItemIdentifier,
                                            AttributeId = item.coiId,
                                            AttributeValue = item.coiIdentifier,
                                            ParentId = parentId,
                                            AttributeType = "MBM",
                                            DT_Stamp = DateTime.Now,
                                            VERSION = orderVersion
                                        });
                    ctxParser.TBL_SERVICE_ORDER_ATTRIBUTES_VERSIONING.AddRange(listToInsert);
                    ctxParser.SaveChanges();
                }
            }
