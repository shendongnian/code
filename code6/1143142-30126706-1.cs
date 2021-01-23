	@model IEnumerable<Treatment>
	@{
		ViewBag.Title = "Index";
		Layout = "~/Views/Shared/_Layout.cshtml";
	}
	<h2>Quickly Generate Invoice</h2>
	@using (Html.BeginForm("Index", "GenerateInvoice", FormMethod.Get))
	{
		@Html.AntiForgeryToken()
		@Html.DropDownList("CompanyId", (SelectList)ViewBag.CompanyId, "Select Company", new { @class = "form-control" })
		<input type="submit" value="Search" class="btn btn-primary" />
	}
	@if(Model != null && Model.Any())
	{
		foreach(var item in Model)
		{
			@Html.DisplayFor(model => item)
		}
	}
