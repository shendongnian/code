    public class ControllerHelper
    {
        public List<SelectListItem> FetchListItems()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            var cat = (from c in db1.ulriken_tblSubMenu where c.fkMainMenuID == 1 && 
            c.Status == true select new { c.pkSubMenuID,c.SubManuName }).ToArray();
            for (int i = 0; i < cat.Length; i++)
            {
                list.Add(new SelectListItem
                {
                    Text = cat[i].SubManuName,
                    Value = cat[i].pkSubMenuID.ToString(),
                    Selected = (cat[i].pkSubMenuID == 1)
                });
            }
        return list;
        }
    }
