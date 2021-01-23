     foreach (ListItem li in cblRoles.Items)
        {
        	if (rd.RoleID.ToString() ==  li.Value)
        	{
        		li.Selected = true;
        	}
        	else
        	{
        		li.Selected = false;
        	}
        }
