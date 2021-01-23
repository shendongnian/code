	public class Origin
	{
		public string originName { get; set; }
		public static List<Origin> PopulateOriginCombo(CableID_QueryView QView)
		{
			if (QView.cmbAreaCode.Text != "")
			{
			   //Code...
			}
		}
		public static List<Origin> PopulateOriginCombo(CableID_CreateView CView)
		{
			if (CView.cmbAreaCode.Text != "")
			{
			   //Code...
			}
		}
	}
