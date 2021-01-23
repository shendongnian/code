    ViewData["CompositeData"] = (
                from a in _db.Task.AsEnumerable()
                join b in _db.Product on a.ProductId equals b.ProductId
                select new MyViewModel
                {
                    TaskId = a.TaskId,
                    TaskDesc = a.TaskDescription,
                    ProdDesc = b.ProductDescription
                }).ToList();
