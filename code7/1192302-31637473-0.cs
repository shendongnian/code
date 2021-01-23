    public class RequiredLocalizedAttribute : RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            this.ErrorMessage = ResourceUtils.GetDisplayName(resourceKey);
    		return base.FormatErrorMessage(name);
        }
    }
