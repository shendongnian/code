    if (parentNode == null && ModelMetadata.Model == null)
    {
        string trueModelStateKey = ModelBindingHelper.CreatePropertyModelName(ModelStateKey, ModelMetadata.GetDisplayName());
        modelState.AddModelError(trueModelStateKey, SRResources.Validation_ValueNotFound);
        return;
    }
