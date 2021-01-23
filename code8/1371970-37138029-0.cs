    public static SelectList Titles(string selectedValue)
    {
        List<SelectListItem> titles = new List<SelectListItem>();
        titles.Add(new SelectListItem { Text = "Prof.", Value = "Prof." });
        titles.Add(new SelectListItem { Text = "Dr.", Value = "Dr." });
        titles.Add(new SelectListItem { Text = "Miss", Value = "Miss" });
        titles.Add(new SelectListItem { Text = "Mr.", Value = "Mr.", Selected = true });
        titles.Add(new SelectListItem { Text = "Mrs.", Value = "Mrs." });
        titles.Add(new SelectListItem { Text = "Ms.", Value = "Ms." });
        SelectList sl = new SelectList(titles, "Value", "Text");//, selectedValue);
        return sl;
    }
