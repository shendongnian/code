	<td>
		@if (item.IsSuccess)
		{
			@Html.ActionLink("Edit", "Edit", new { id = item.Id })@: |
			@Html.ActionLink("Details", "Details", new { id = item.Id })@: |
			@Html.ActionLink("Delete", "Delete", new { id = item.Id })
		}
	</td>
