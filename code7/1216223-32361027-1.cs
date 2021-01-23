    @model WebGridTest.Models.MyHeader
    
    @{
        ViewBag.Title = "Home Page";
    }
    
    @using (Html.BeginForm(actionName: "Index", controllerName: "Home", method: FormMethod.Post))
    {
    	<p></p>
    	@Html.TextBoxFor(x => x.Id)
    	<p></p>
    	WebGrid grid = new WebGrid(null, canPage: false);
    	grid.Bind(Model.MyDetails);
    
    	@grid.GetHtml(tableStyle: "table table-bordered lookup-table", columns:
    		grid.Columns(
    			grid.Column(
    				"Column1"
    				, "Column 1"
    				, (item) => (item.Column1)
    			)
    			,
    			grid.Column(
    				"Column2"
    				, "Column 2"
    				, (item) => (item.Column2)
    			)
    			,
    			grid.Column(
    				"Column3"
    				, "Column 3"
    				, (item) => (item.Column3)
    			)
    		)
    	).AddRouteValuesToWebGridHeaders("Id=" + Model.Id.ToString())
    }
