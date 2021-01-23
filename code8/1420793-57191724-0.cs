    public IActionResult Error(int? statusCode = null)
    {
        if (statusCode.HasValue)
        {
            Log.Error($"Error statusCode: {statusCode}");
            if (statusCode == 403)
            {
                return View(nameof(AccessDenied));
            }
            if (statusCode == 404)
            {
                return View(nameof(PageNotFound));
            }
        }
    
        return View(new ErrorViewModel 
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
    }
