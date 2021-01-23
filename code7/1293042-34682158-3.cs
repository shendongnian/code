    private SelectList GetGenders()
    {
        using (testContext test = new testContext())
        {
            List<SelectListItem> listselecteditem = new List<SelectListItem>();
            foreach (Gender item in test.genders)
            {
                SelectListItem selectlist = new SelectListItem()
                {
                    Text = item.GenderType,
                    Value = item.GenderID.ToString(),
                };
                listselecteditem.Add(selectlist);
            }
            return new SelectList(listselecteditem, "Value", "Text");
        }
    }
