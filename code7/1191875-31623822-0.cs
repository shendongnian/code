    @if (Session["UserAndRolesList"] != null)
    { 
        @{var firstRole = (Session["UserAndRolesList"] as List<NMS.User.Entities.DTO.UserRole>).First();}
        <span> Hello! @firstRole.FirstName</span>
    }
    else
    {
        <span>Hello! Gust user</span>
    }
