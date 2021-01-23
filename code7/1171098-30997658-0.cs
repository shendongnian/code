    // refresh tenant because otherwise it stays in setup mode
    var tenant = _tenantService.GetTenants().FirstOrDefault(ss => ss.Name == name);
    if (tenant == null) return HttpNotFound();
    tenant.State = TenantState.Disabled;
    _tenantService.UpdateTenant(tenant);
    
    var tenant2 = _tenantService.GetTenants().FirstOrDefault(ss => ss.Name == name);
    if (tenant2 == null) return HttpNotFound();
    tenant2.State = TenantState.Running;
    _tenantService.UpdateTenant(tenant2);
