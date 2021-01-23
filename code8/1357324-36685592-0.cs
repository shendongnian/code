    protected string GetValidDate(string inputDate)
        {
            DateTime dateObject;
            if (DateTime.TryParse(inputDate, out dateObject))
            {
                return dateObject.ToString("dddd, MMMM dd, yyyy");
            }
            else
            {
                return "invalid Input";
            }
        }
