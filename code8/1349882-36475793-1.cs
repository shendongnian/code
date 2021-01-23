	@grid.GetHtml(
		htmlAttributes: new { id="productSearchGrid" },
		mode:WebGridPagerModes.All,
		tableStyle: "table table-hover table-bordered table-responsive",
		columns: grid.Columns(
			grid.Column("ID", "Product ID", style: "span1", canSort: true),
			grid.Column("ProductTypeDescription", "Product Type", style: "span2", canSort: true),
			grid.Column("ProductName", "Product Name", style: "span2", canSort: true),
			grid.Column("Price", "Current Price", format: (item) => String.Format("{0:C}", @item.Price), style: "span2", canSort: true),
			grid.Column("EffectiveDate", "Effective Date", (format: (item) => (item.EffectiveDate != DateTime.MinValue && item.EffectiveDate
				!= null ? new HtmlString(
				item.EffectiveDate.ToString("yyyy-MM-dd")
				).ToString() : new HtmlString("---").ToString())), style: "span2", canSort: false),
			grid.Column("TerminateDate", "Terminate Date", (format: (item) => (item.TerminateDate != DateTime.MinValue && item.TerminateDate
				!= null ? @Html.Raw(("<span id='' title='" + item.Price + "'>" + item.TerminateDate.ToString("yyyy-MM-dd")
				).ToString() + "</span>") : new HtmlString("---").ToString())), style: "span2", canSort: false),
			grid.Column("Select", format: (item) =>
				new HtmlString(
				Html.ActionLink("Select", "AddOrEditProduct", "Product", new
					{
						productID = item.ID
					}, null).ToString()
				)
			)
		)
	)
