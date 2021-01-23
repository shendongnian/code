    /// <summary>
    /// Validate inputs and update ModelState with errors
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var parameters = context.ActionDescriptor.Parameters.Cast<ControllerParameterDescriptor>().ToDictionary(p => p.Name);
            foreach (var kvp in context.ActionArguments)
            {
                if (kvp.Value == null)
                {
                    if (!parameters[kvp.Key].ParameterInfo.IsOptional)
                    {
                        context.ModelState.AddModelError($"{kvp.Key}", "Parameter is required");
                    }
                    continue;
                }
                var results = new List<ValidationResult>();
                var vc = new ValidationContext(kvp.Value);
                if (!Validator.TryValidateObject(kvp.Value, vc, results))
                {
                    var errs = from vr in results
                               from member in vr.MemberNames
                               select new { Member = member, vr.ErrorMessage };
                    foreach (var err in errs)
                    {
                        context.ModelState.AddModelError($"{kvp.Key}.{err.Member}", err.ErrorMessage);
                    }
                }
            }
        }
    }
