    @Html.RestrictedActionLink("Edit", "Edit", "Parameter", new[] { "Admin" }, this.User, new { vendorId = Model.VendorId, effectiveDate = Model.EffectiveDate, createNew = false })
    
    @if (Model.AllowCancel)
    {
        @Html.RestrictedActionLink("Copy", "Edit", "Parameter", new[] { "Admin" }, this.User, new { vendorId = Model.VendorId, effectiveDate = Model.EffectiveDate });
    }
    @if (Model.AllowCancel)
    {
        @Html.RestrictedActionLink("Cancel...", "", "", new[] { "Admin" }, User, null, new { @class = "CancelParam", vendorId = Model.VendorId, effectiveDate = Model.EffectiveDate, disabled = !Model.AllowCancel });
    }
