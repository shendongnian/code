    @if (Html.RenderContext.Context.CurrentUser.IsAuthenticated())
    {
        if (Html.RenderContext.Context.CurrentUser.Claims.Contains("Admin"))
        {
            @Html.Partial("Views/Partials/_AdminMenu")
        }
        else if (Html.RenderContext.Context.CurrentUser.Claims.Contains("Editor"))
        {
            @Html.Partial("Views/Partials/_EditorMenu")
        }
        else if (@Html.RenderContext.Context.CurrentUser.Claims.Contains("Viewer"))
        {
            @Html.Partial("Views/Partials/_ViewerMenu")
        }
        else
        {
            @Html.Partial("Views/Partials/_PublicMenu")
        }
    }
    else
    {
        @Html.Partial("Views/Partials/_PublicMenu")
    }
