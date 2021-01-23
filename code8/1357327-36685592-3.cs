    protected string GetValidDate(object inputDate)
    {
        DateTime dateObject;
        if (inputDate != null)
        {
            if (DateTime.TryParse(inputDate.ToString(), out dateObject))
            {
                return dateObject.ToString("dddd, MMMM dd, yyyy");
            }               
        }
        return "invalid Input";
    }
