    try {
            if(DateTime.TryParseExact(value, "MM/dd/yyyy", CultureInfo.InvariantCulture, out TempDate)
            {
                 InitialStartDate=TempDate;
            }
            else 
            {
                 InitialStartDate = null;
                 ModelState.AddModelError("Date is not right");
            }
    }
    catch (ArgumentException e)
    {
        ModelState.AddModelError("Date is not right");
    }
