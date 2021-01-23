    // Validate a field
    if (string.IsNullOrWhiteSpace(viewModel.Name))
    { 
        // Add a validation error
        this.ModelState.AddModelError("FieldName", "This is an error");
    }
    if (this.ModelState.IsValid())
    {
        // Do something...
    }
