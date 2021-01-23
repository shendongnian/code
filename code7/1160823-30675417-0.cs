    @{
        var clientId = 0;
        if (Model.Any())
        {
            clientId = Model.First().ClientId;
        }
     }
     @Html.ActionLink("Add PO", "Create", "POCorns", new {ClientID = clientID },null)
