@if (Model.Name != null)
{
    string flagComments;
    bool isFlagged = Model.IsFlaggedEmail(out flagComments);
    <div>
        @Model.Name, <span id="@Html.Raw(isFlagged? "flagged": "")">@Model.Email</span>
