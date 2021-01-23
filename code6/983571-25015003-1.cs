    [HttpPost]
    public string SaveResults(List<int> location_code)
    {
        if (location_code!= null)
        {
            return string.Join(",", location_code);
        }
        else
        {
            return "No values are selected";
        }
    }
