    <td>
            @* I'd like to make this editor enabled only when model.IsManualInput is true *@
            @if (Model.IsManualInput)
            {
                @Html.TextBoxFor(model => model.TargetDate, new { @maxlength = "12" })
            }
            else
            {
                @Html.TextBoxFor(model => model.TargetDate, new { @maxlength = "12",
                                                                 @disabled = "disabled" })
            }
    </td>
