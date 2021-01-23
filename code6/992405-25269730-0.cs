        public IEnumerable<SelectListItem> GetSelection<T>(IEnumerable<T> data,
           Func<T, string> name = null,
           Func<T, string> key = null,
           string defaultValue = "0",
           bool showAllValue = true,
           bool showNothing = false)
        {
            var selectItemList = new List<SelectListItem>();
            if (showAllValue)
            {
                selectItemList.Add(new SelectListItem { Text = "Choose All", Value = 0 });
            }
            if (showNothing)
            {
                selectItemList.Add(new SelectListItem { Text = "Nothing Selected", Value = -1 });
            }
            selectItemList.AddRange(data.Select(item => key != null ? (name != null ? new SelectListItem
            {
                Text = name(item),
                Value = key(item)
            } : null) : null));
            //default selection
            var defaultItem = selectItemList.FirstOrDefault(x => x.Value == defaultValue);
            if (defaultItem != null)
            {
                defaultItem.Selected = true;
            }
            else
            {
                var firstItem = selectItemList.FirstOrDefault();
                if (firstItem != null) firstItem.Selected = true;
            }
            return selectItemList;
        }
      
