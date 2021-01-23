    public class RequiredLocalizedAttribute : RequiredAttribute
    {
        ResourceUtils.ResourceKey _resourceKey;
        public RequiredLocalizedAttribute(ResourceUtils.ResourceKey resourceKey)
        {
            this._resourceKey = resourceKey;
        }
        public override string FormatErrorMessage(string name)
        {
            this.ErrorMessage = ResourceUtils.GetDisplayName(resourceKey);
    		return base.FormatErrorMessage(name);
        }
    }
