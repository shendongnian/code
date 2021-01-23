	<td>
		@if (item.IsSuccess)
		{
			@Html.ActionLink("Edit", "Edit", new { id = item.Id })<text> |</text>
			@Html.ActionLink("Details", "Details", new { id = item.Id })<text> |</text>
			@Html.ActionLink("Delete", "Delete", new { id = item.Id })
		}
	</td>
