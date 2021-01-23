	public static List<SelectListItem> GetEnumList(Enum value)
	{
		return Enum.GetValues(value.GetType())
				.Cast<Enum>()
				.Select(v => new SelectListItem
							{
								Text = v.ToString(),
								Value = Convert.ToInt32(v).ToString()
							})
				.ToList();
	}
