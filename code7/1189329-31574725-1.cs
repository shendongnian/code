    protected void ExportExcelFile(object Sender, EventArgs e) { //export to excel
			var grdResults = new DataGrid(); // REF: https://stackoverflow.com/q/28155089/153923
			if (periodCriteria.SelectedValue == "year") {
				grdResults = RollupDG;
			} else {
				grdResults = QuarterDG;
			}
			var response = HttpContext.Current.Response;
			response.Clear();
			response.Charset = String.Empty;
			response.ContentType = "application/vnd.ms-excel";
			response.AddHeader("Content-Disposition", "attachment; filename=GlBudgetReport.xls");
			using (var sw = new StringWriter()) {
				using (var htw = new HtmlTextWriter(sw)) {
					grdResults.RenderControl(htw);
					response.Write(sw.ToString());
					response.End();
				}
			}
    }
