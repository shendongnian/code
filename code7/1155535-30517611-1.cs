			var org = modelBuilder.Entity<Organization>()
				.Map(u =>
				{
					u.Properties(m => new { m.TenantId, m.Name });
				})
				.HasRequired(m => m.Settings)
				.WithRequiredPrincipal();
			modelBuilder.Entity<OrganizationSettings>()
				.HasKey(m => m.OrganizationId);
