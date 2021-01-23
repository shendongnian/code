    RunCodeWithNewClientContext((ctx, item) => {
        const string template = "i:0#.f|membership|{0}@<tenant>.onmicrosoft.com";
        var modifiedBy = ctx.Web.EnsureUser(string.Format(template, vm.ModifiedBy));
        var createdBy = ctx.Web.EnsureUser(string.Format(template, vm.CreatedBy));
        ctx.Load(modifiedBy);
        ctx.Load(createdBy);
        ctx.ExecuteQuery();
        item["Editor"] = modifiedBy.Id;
        var modifiedByField = new ListItemFormUpdateValue {
            FieldName = "Modified_x0020_By",
            FieldValue = modifiedBy.Id.ToString()
        };
        item["Author"] = createdBy.Id;
        var createdByField = new ListItemFormUpdateValue {
            FieldName = "Created_x0020_By",
            FieldValue = createdBy.Id.ToString()
        };
        item["Modified"] = vm.ModifiedAt.ToUniversalTime();
        item["Created"] = vm.CreatedAt.ToUniversalTime();
        // it doesn't matter if you add both modifiedByField and createdByField.
        // As long as the list is non-empty all changes appear to carry over.
        var updatedValues = new List<ListItemFormUpdateValue> { modifiedByField, createdByField };
        item.ValidateUpdateListItem(updatedValues, true, "Ignored on explicit checkin/checkout");
        ctx.ExecuteQuery();
    });
