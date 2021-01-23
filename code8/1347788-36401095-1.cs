    List<ViewModel> list1 = new List<ViewModel>();
    
    var query1 = db.Table1.Where(er => er.ID == Filter1)
                          .Select(er => new ViewModel
                            {
                                //columns here 
                            }).ToList().LastOrDefault(); 
    list1.Add(query);
    
    var query2 = db.Table2.Where(er => er.ID == Filter2)
                          .Select(er => new ViewModel
                            {
                                //columns here 
                            }).ToList().LastOrDefault(); 
    list1.Add(query);
 
    var query3 = db.Table3.Where(er => er.ID == Filter3)
                          .Select(er => new ViewModel
                            {
                                //columns here 
                            }).ToList().LastOrDefault();
    
    list1.Add(query);
    
    return list1;
