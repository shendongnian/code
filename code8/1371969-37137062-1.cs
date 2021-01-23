    public static SelectList Titles(string selectedValue)
    {
        List<SelectListItem> titles = new List<SelectListItem>();
        titles.Add(new SelectListItem { Text = "Prof.", Value = "1" });
        titles.Add(new SelectListItem { Text = "Dr.", Value = "2" });
        titles.Add(new SelectListItem { Text = "Miss.", Value = "3" });
        titles.Add(new SelectListItem { Text = "Mr.", Value = "4" });
        titles.Add(new SelectListItem { Text = "Mrs.", Value = "5" });
        titles.Add(new SelectListItem { Text = "Ms.", Value = "6" });
        SelectList sl = new SelectList(titles, "Value", "Text", selectedValue);
        return sl;
    }
