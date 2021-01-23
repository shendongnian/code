    if (int.TryParse(HttpContext.Current.Request["section"], out section)
                && int.TryParse(HttpContext.Current.Request["position"], out position))
    {
         ProcessData();
    }
