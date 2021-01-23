    @helper GetSubMenus(IEnumerable<menutable> siteMenu, Nullable<int> parentID)
    {
        foreach (var i in Model.Where(a => a.ParentID.Equals(parentID)))
        {
            var submenu = Model.Where(a => a.ParentID.Equals(i.MenuID)).Count();
           
            <li class="@(submenu > 0 ? "dropdown-submenu" : "dropdown")">
                <a href="@(!string.IsNullOrEmpty(i.MenuLink) ? Url.Content(i.MenuLink) : "~/default)" style="font-size:16px;">@i.MenuName</a>
                @if (submenu > 0)
                {
                    <ul class="dropdown-menu">
                        @GetSubMenus(siteMenu, i.MenuID)
                        @* Recursive  Call for Populate Sub items here*@
                    </ul>
                }
            </li>
        }
    }
    
    @{
        var mymenu = @Model;
        var menuParentID = mymenu.First().ParentID;
    }  
    @if (mymenu != null && mymenu.Count() > 0)
    {
        <nav class="navbar navbar-default">
            <div class="container-fluid">
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class=" nav navbar-nav">
                        @GetSubMenus(mymenu, menuParentID)
                    </ul>
                </div>
            </div>
        </nav>
    } 
