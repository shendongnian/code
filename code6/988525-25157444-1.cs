    static class FormExtension
	{
		public static void Visible(this IEnumerable<Control> elem, bool state)
		{
			foreach (var item in elem)
				item.Visible = state;
		}
	}
