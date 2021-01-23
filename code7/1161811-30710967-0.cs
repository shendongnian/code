    // this projection
    Projections
        .Property(() => tenantOrderAlias.InstallationStatus)
        .WithAlias(() => tenantDto.InstallationStatusName //?   ));
    // could be converted into string values with this statement
    Projections
        .Conditional(
            Restrictions.Where<TenantOrder>(to => 
                to.InstallationStatus == TenantInstallationStatusEnum.TS0),
            Projections.Constant("MS3_TenantInstallationStatus_TS0"),
            Projections.Constant("MS3_TenantInstallationStatus_TS2")
        ).WithAlias(() => tenantOrderAlias.InstallationStatusName)
    );
