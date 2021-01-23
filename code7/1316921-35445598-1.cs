    @model ClientPaymentInfo
    <h2>Payments of @Model.ClientName</h2>
    @foreach(var item in Model.Payments)
    {
      <p>@item.Amount</p>
      <p>
        @Html.ActionLink("Edit", "Edit", new { id=item.Id }) |
        @Html.ActionLink("Details", "Details", new { id=item.Id }) |
        @Html.ActionLink("Delete", "Delete", new { id=item.Id })
      </p>
      
    }
    <p>Total : @Model.Payments.Sum(s=>S.Amount)
