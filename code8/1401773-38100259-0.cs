    public IQueryable ReturnCart(int cid)
        {
            try 
            {
                var result = (from c in veps.ecomCarts
                              where c.ClientID == cid
                              select new 
                              {
                                  _ID = c.ID,
                                  _CID = c.ClientID,
                                  _UPC = c.UPC,
                                  _Description = c.Description,
                                  _Quantity = c.Quantity,
                                  _UnitPrice = c.UnitPrice,
                                  _Discount = c.Discount,
                                  _Total = c.Total,
                                  _InProgress = c.InProgress,
                                  _dts = c.dts,
                                  lcdp = from d in veps.lawFirmClientDocumentPurchaseds
                                         select new
                                         {
                                             _DOCID = d.ID
                                         }
                              });
                
                return result;
            }
            catch (Exception ex)
            {
                _IsError = true;
                _ErrorMsg = ex.Message;
                return null;
            }
        }
