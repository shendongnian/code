        if (model.ActiveIndicator == null)
        {
            model.ActiveIndicator = ((DefaultValueAttribute)(model.GetType().GetProperty("ActiveIndicator").GetCustomAttributes(typeof(DefaultValueAttribute), true).First())).Value.ToString();
            ModelState.SetModelValue("ActiveIndicator", new ValueProviderResult(catalog_Reports.ActiveIndicator, "", CultureInfo.InvariantCulture));
            ModelState["ActiveIndicator"].Errors.Clear(); // Removes Model Error
        }
