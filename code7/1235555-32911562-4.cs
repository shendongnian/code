		public async Task SetupAccessControl(int objectTypeId, int objectId, int? organizationId)
		{
			var tasks = new List<Task>();
			using (var context = new SupportContext(CustomerId))
			{
				... // omitted for brevity
				if (objectTypeId == (int) ObjectType.User)
				{
					tasks.Add(AddToUserRoleBridge("Everyone", objectId));
					tasks.Add(AddToUserRoleBridge("Default", objectId));
				}
				... // omitted for brevity
			}
			
			await Task.WhenAll(tasks.ToArray());
		}
