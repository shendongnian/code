    public static SelectList Titles(string selectedValue)
    {
        List<SelectListItem> titles = new List<SelectListItem>();
        titles.Add(new SelectListItem { Id = "1", Value = "Prof." });
        titles.Add(new SelectListItem { Id = "2", Value = "Dr." });
        titles.Add(new SelectListItem { Id = "3", Value = "Miss" });
        titles.Add(new SelectListItem { Id = "4", Value = "Mr." });
        titles.Add(new SelectListItem { Id = "5", Value = "Mrs." });
        titles.Add(new SelectListItem { Id = "6", Value = "Ms." });
        SelectList sl = new SelectList(titles, "Id", "Value", selectedValue);
        return sl;
    }
