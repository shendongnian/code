                Default.Container context = new Default.Container(new Uri("url_to_OData_Service"));
            var nquery = context.Reports
                                   .Where(r => r.ReportId == 1)
                                   .Select(p => p);
            DataServiceQuery<Report> query = (DataServiceQuery<Report>)nquery;
            TaskFactory<IEnumerable<Report>> taskFactory = new TaskFactory<IEnumerable<Report>>();
            IEnumerable<Report> result = await taskFactory.FromAsync(query.BeginExecute(null, null), iar => query.EndExecute(iar));
            
