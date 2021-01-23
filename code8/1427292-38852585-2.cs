    class SampleModel : IValidatableObject
    {
        public Guid? ComponentID { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;
            Guid componentid = (Guid)value;
            int modelid = System.Web.HttpContext.Current.Request.RequestContext.RouteData.GetWebApiRouteData("modelid");
            Model context_mdl = Model.GetModel(modelid);
            if(!context_mdl.HasComponent(componentid))
            {
                yield return new ValidationResult(string.Format("Invalid component"));
            }
        }
    }
