	@(Html.Kendo()
		.Grid<MyModel>()
		.Name("grid").Columns(columns =>
		{
			columns.ForeignKey(o => o.MyEnum, ).EditorTemplateName("GridForeignKey").Width(200);
			
			// SNIP
			
			
			
