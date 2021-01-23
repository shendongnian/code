    public ActionResult Index(WorkOrder model, int? page, int? page_size, string start_date, string end_date, string org)
            {
                if (model.work_form == null)
                {
                    if (start_date != null && end_date != null && org != null)
                    {
                        var form = new WorkOrderForm
                        {
                            start_date = start_date,
                            end_date = end_date,
                            org = org
                        };
                        model.work_form = form;
                    }
                }
    
                if (model.work_form != null)
                {
                    using (OracleDbctx ctx = new OracleDbctx())
                    {
                        //do database stuff
                        //var list = database(query).ToList()
                        int pageNumber = (page ?? 1);
                        int pageSize = (page_size ?? 20);
                        int count = list.Count;
                        if (pageNumber - 1 > count / page_size)
                        {
                            pageNumber = 1;
                        }
    
    
                        model.view_list = list.ToPagedList(pageNumber, pageSize);
    
                        return View(model);
                    }
                }
    
                return View();
            }
