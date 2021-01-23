        if (model.ActiveIndicator == null)
        {
            var defValue = ((DefaultValueAttribute)(model.GetType().GetProperty("ActiveIndicator").GetCustomAttributes(typeof(DefaultValueAttribute), true).First())).Value.ToString();
            ModelState.SetModelValue("ActiveIndicator", new ValueProviderResult(defValue, "", CultureInfo.InvariantCulture));
            ModelState["ActiveIndicator"].Errors.Clear(); // Removes Model Error
        }
