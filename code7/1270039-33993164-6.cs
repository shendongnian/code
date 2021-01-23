        [WebMethod]
            public List<ca_ConfigiDeal> Get_iDealConfig(String caller, Guid? prefixSA,out ReturnStatus returnStatus, out String errorMessage)
            {
                var list = new List<object>();
                DateTime _startTime = DateTime.Now;
                String _spName = "Get_iDealConfig";
                Object _parameters = new { caller, prefixSA };
        
                returnStatus = ReturnStatus.Unspecified;
                _customMessage = String.Empty;
                ERGODataContext _context = null;
        
             try
                {
                    _context = get_DBContext2();
                    var _list = _context.ca_ConfigiDeals.Where(x => x.isDeleted == false);
                    if (prefixSA.HasValue)
                         _list = _list.Where(x => x.PrefixSA == prefixSA);
                    foreach(var item in _list){
                       var temp = new {
                            PrefixSA = _context.BizV.Find(item.PrefixSA).ShortDes,
                            CodeCalendar = _context.BizV.Find(item.CodeCalendar).ShortDesc,
                            Product = _context.BizV.Find(item.Product).ShortDesc,
                            RequestType = _context.BizV.Find(item.RequestType).ShortDesc
                        };
                    list.Add(temp);
                    };
       
    
                     if (new_list.Count == 0)
                        {
                            returnStatus = ReturnStatus.NoRecord;
                        }
                        else
                            returnStatus = ReturnStatus.Success;
            
                    }
                catch (Exception ex)
                {
                    handleExcept(ref returnStatus, caller, ex, _spName, _parameters, _startTime);
                    _customMessage = ex.Message;
                }
                finally
                {
                     errorMessage = String.Format("{0}: {1}.{2}", (Int32)returnStatus, returnStatus.ToString(),
                     String.IsNullOrEmpty(_customMessage) ? String.Empty : String.Format(" {0}.", _customMessage));
                     traceEnd(_context, caller, _spName, _parameters, _startTime, returnStatus, errorMessage);
                }
    
            return list;
