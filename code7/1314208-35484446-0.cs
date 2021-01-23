       @model IEnumerable<Menus>
    
    @helper GetSubMenus(IEnumerable<Menus> siteMenu, int? parentID)
    {  
        foreach (var i in Model.Where(a => a.ParentID.Equals(parentID)))
        {       
            <li class="@(i.ParentID.HasValue ? "dropdown-submenu" : "dropdown")">
                <a href="@(!string.IsNullOrEmpty(i.MenuLink) ? Url.Content(i.MenuLink) : "~/ADDS/Default.aspx")" style="@(i.ParentID.HasValue ? "" : "font-size:16px;")">@i.MenuName</a>
                @if (Model.Any(a => a.ParentID.Equals(i.MenuID)))
                {                             
                    <ul class="dropdown-menu">
                        @GetSubMenus(siteMenu, i.MenuID)
                        @* Recursive  Call for Populate Sub items here*@
                    </ul>
                }
            </li>
        }
    }
    
    @if (@Model.IsAny())
    {
        <nav class="navbar navbar-default">
            <div class="container-fluid">
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class=" nav navbar-nav">
                        @GetSubMenus(@Model, @Model.First().ParentID)
                    </ul>
                </div>
            </div>
        </nav>
    } 
