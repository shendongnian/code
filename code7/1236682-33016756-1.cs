     this._context = Substitute.For<IDerivedContext>();
     this._permissionSet = Substitute.For<IGlqcSet<Permission>> ();
     this._permission1 = new Permission
            {
                UserID = 1,
                MenuID = 26,
                PermissionAllow = true
            };
     var queryable = (new List<Permission> { this._permissionLink1 }).AsQueryable();
     this._permissionSet.Any(Arg.Any<Expression<Func<Permission, bool>>>()).Returns(x => queryable.Any((Expression<Func<Permission, bool>>)x[0]));
     
     var result = this._permissionsProvider.HasPermissionToSomething(this._context, 1);
     Assert.IsTrue(result);
