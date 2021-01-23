        public static List<SelectListItem> Gettypes()
        {
            var types = new List<SelectListItem> {new SelectListItem {Value= "0", Text = "--- Choose ---"} };
            types.AddRange(Enum.GetNames(typeof(MyEnum)).Select(x => new SelectListItem {Value = x, Text = x}).ToList());
            return types;
        }
