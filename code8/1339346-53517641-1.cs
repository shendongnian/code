		public static List<SelectListItem> Gettypes()
		{
			var enums = Enum.GetNames(typeof(WorkLogType)).ToList();
			var selectLIst = enums.Select(x => new SelectListItem {Value = x, Text = x}).ToList();
			return selectLIst;
		}
