    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateMustHaveAtLeastOne : ValidationAttribute, IClientValidatable {
    #region Construnctor
    public ValidateMustHaveAtLeastOne(string groupName, string validationMessage, string dependentProperty, object targetValue) {
      GroupName = groupName;
      ValidationMessage = validationMessage;
	  
	  DependentProperty = dependentProperty;
      TargetValue = targetValue;
    }
    #endregion
    #region Properties
    /// <summary>
    /// Name of the group of the properties
    /// </summary>
    public string GroupName { get; private set; }
    /// <summary>
    /// Vaidation message
    /// </summary>
    public string ValidationMessage { get; private set; }
	
	/// <summary>
	/// Gets or sets the dependent property.
	/// </summary>
	/// <value>
	/// The dependent property.
	/// </value>
	public string DependentProperty { get; set; }
	/// <summary>
	/// Gets or sets the target value.
	/// </summary>
	/// <value>
	/// The target value.
	/// </value>
	public object TargetValue { get; set; }
    #endregion
    #region Public overrides
    /// <summary>
    /// Validates the group of properties.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="context">The context information about the validation operation.</param>
    /// <returns>An instance of the ValidationResult class.</returns>
    protected override ValidationResult IsValid(object value, ValidationContext context) {
		var containerType = validationContext.ObjectInstance.GetType();
		var field = containerType.GetProperty(this.DependentProperty);
		if (field != null)
		{
			// get the value of the dependent property
			var dependentvalue = field.GetValue(validationContext.ObjectInstance, null);
			// compare the value against the target value
			if ((dependentvalue == null && this.TargetValue == null)
				|| (dependentvalue != null && dependentvalue.Equals(this.TargetValue)))
			{
				foreach (var property in GetGroupProperties(context.ObjectType)) {
				var propertyValue = property.GetValue(context.ObjectInstance, null);
				if (propertyValue != null) {
				  return null;
					}
			  }
			  return new ValidationResult(ValidationMessage);
			}
		}
	
      return ValidationResult.Success;
    }
    #endregion
    #region Implementation of IClientValidateable
    /// <summary>
    /// To enable client side implementation of same validtion rule.
    /// </summary>
    /// <param name="metadata">The model metadata.</param>
    /// <param name="context">The controller context.</param>
    /// <returns>The client validation rules for this validator.</returns>
    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context) {
      var groupProperties = GetGroupProperties(metadata.ContainerType);
      List<string> propertyNames = new List<string>();
      foreach (var property in groupProperties) {
        propertyNames.Add(property.Name);
      }
      var rule = new ModelClientValidationRule {
        ErrorMessage = this.ValidationMessage
      };
      rule.ValidationType = string.Format("group", GroupName.ToLower());
      rule.ValidationParameters["propertynames"] = string.Join(",", propertyNames);
	  
	  string depProp = this.BuildDependentPropertyId(metadata, context as ViewContext);
	  // find the value on the control we depend on; if it's a bool, format it javascript style
	  string targetValue = (this.TargetValue ?? string.Empty).ToString();
	  if (this.TargetValue.GetType() == typeof(bool))
	  {
		 targetValue = targetValue.ToLower();
	  }
	  
	  rule.ValidationParameters["dependentproperty"] = depProp;
	  rule.ValidationParameters["targetvalue"] = targetValue;
      yield return rule; // yield key word is used as return type is  declared as IEnumerable<ModelClientValidationRule>
    }
    #endregion
        /// Returns the group of properties that implements this attribute
    /// </summary>
    /// <param name="type">Type of the Model</param>
    /// <returns>List of properties</returns>
    private IEnumerable<PropertyInfo> GetGroupProperties(Type type) {
      var propertyInfo = new List<PropertyInfo>();
      foreach (PropertyInfo property in type.GetProperties()) {
        if (property.GetCustomAttributes(typeof(ValidateMustHaveAtLeastOne), false).GetLength(0) > 0) {
          propertyInfo.Add(property);
        }
      }
      return propertyInfo;
    }
	
     private string BuildDependentPropertyId(ModelMetadata metadata, ViewContext viewContext)
	{
		string depProp = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(this.DependentProperty);
		// This will have the name of the current field appended to the beginning, because the TemplateInfo's context has had this fieldname appended to it.
		var thisField = metadata.PropertyName + "_";
		if (depProp.StartsWith(thisField, StringComparison.OrdinalIgnoreCase))
		{
			depProp = depProp.Substring(thisField.Length);
		}
		return depProp;
	} 
