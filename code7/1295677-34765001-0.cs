    ViewData["total"] = rawData.Count();
    
                // Apply paging
                if (request.Page > 0)
                {
                    gridData = rawData.Skip((request.Page - 1) * request.PageSize).ToList();
                }
    
                    gridData = rawData.Take(request.PageSize).ToList();
    
    
                var result = new DataSourceResult()
                {
                    Data = gridData,
                    Total = (int)ViewData["total"]
                };
    
                return Json(result);
