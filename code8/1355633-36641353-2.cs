    @if(ViewBag.IsReadonly)
    {
        @Html.Partial("_ReadOnlyClientDetails", viewModel.Client)
    }
    else
    {
        @Html.Partial("_ClientDetails", viewModel.Client)
    }
