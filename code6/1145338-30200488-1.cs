    public class AModel
    {
        public List<AnotherModel> Items { get; set; }
    }
    public class AnotherModel
    {
        public int ApplicationId { get;set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicantName { get; set; }
        public bool Selected { get; set; }
    }
	@using (Html.BeginForm("PostIndex", "Home", FormMethod.Post))
	{
		<table class="table" style="margin-bottom: 0px">
			<tbody>
			@for (var i = 0; i < Model.Items.Count(); i++)
			{
				<tr>
					<td>
						<label>@Html.CheckBoxFor(model => model.Items[i].Selected) @Html.DisplayFor(model => model.Items[i].ApplicantName)</label>
					</td>
					<td>
						@Html.ActionLink(Model.Items[i].ApplicationId.ToString(), "ViewApplication", new {ID = Model.Items[i].ApplicationId, edit = 1}, new AjaxOptions {HttpMethod = "GET"})
					</td>
					<td>
						@Html.DisplayFor(model => model.Items[i].ApplicationDate)
					</td>
					<td>
						@Html.DisplayFor(model => model.Items[i].ApplicationId)
					</td>
				</tr>
			}
			</tbody>
		</table>
		<input type="submit"/>
	}
