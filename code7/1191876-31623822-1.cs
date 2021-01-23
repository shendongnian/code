    @if (Session["UserAndRolesList"] != null)
    { 
        var firstRole = (Session["UserAndRolesList"] as List<NMS.User.Entities.DTO.UserRole>).FirstOrDefault();
        if(firstRole!=null)
        {
            <span> Hello! @firstRole.FirstName</span>
        }
    }
    else
    {
        <span>Hello! Gust user</span>
    }
