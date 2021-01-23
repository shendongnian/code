	public static void Refresh(DataGridView view, DataTable table) {
		bool origAuto = view.AutoGenerateColumns;
		view.AutoGenerateColumns = true;
		view.DataSource = table;
		view.BindingContext = new BindingContext();
		view.AutoGenerateColumns = origAuto;
	}
