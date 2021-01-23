	using (var context = new CustomerContext(CustomerID))
	using (var e = new eContext())
	{
		var globalUserList = e.GlobalLoginCustomerBridges
			.Join(e.GlobalLogins,
				glcb => glcb.glcbr_gl_id,
				gl => gl.gl_id,
				(glcb, gl) => new { glcb, gl })
			.Where(n => n.glcb.glcbr_customer_id == CustomerID)
			.Select(n => new User2
			{
				ID = (int)n.glcb.glcbr_user_id,
				GlobalLogin = n.gl.gl_login_name,
				GUID = n.gl.gl_GUID
			}).ToList();
		var customer = e.Customers
			.Join(e.DatabaseConnectionStrings,
			c => c.DatabaseConnectionID,
			d => d.DatabaseConnectionID,
			(c, d) => new { c, d })
			.Select(n => new Customer2
			{
				ID = n.c.CustomerID,
				Name = n.c.CustomerName,
				DatabaseConnectionName = n.d.DatabaseConnectionName,
				DatabaseConnectionString = n.d.DatabaseConnectionString1,
				GUID = n.c.cust_guid,
			}).ToList().FirstOrDefault(n => n.ID == CustomerID);
		var orgs = context.Organizations
			.Select(o => new Organization2
			{
				ID = o.org_id,
				Name = o.org_name,
			}).ToList();
		var users = context.Users
			.Select(n => new User2
			{
				ID = n.UserID,
				FirstName = n.UserFirstName,
			}).ToList();
		var userList = users
			.Join(globalUserList,
				u => u.ID,
				gl => gl.ID,
				(u, gl) => new { u, gl })
			.Join(context.OrganizationObjectBridges,
				u => u.u.ID,
				oob => oob.oob_object_id,
				(u, oob) => new { u, oob })
				.Where(o => o.oob.oob_object_type_id == 9)
			.Select(n => new User2
			{
				ID = n.u.u.ID,
				GlobalLogin = n.u.gl.GlobalLogin,
				FirstName = n.u.u.FirstName,
				GUID = n.u.gl.GUID,
				Customer = customer,
				Organization = orgs.FirstOrDefault(o => o.ID == n.oob.oob_org_id)
			}).Where(n => !isDisabled != null && n.Disabled == isDisabled).ToList();
		return userList;
	}
