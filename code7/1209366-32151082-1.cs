	public partial class ActividadProyecto : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((bool)validationContext.Items["is_insert"]) // insert mode
            {
                // Do stuff
            }
            else // update mode
            {
                // Do other stuff
            }
        }
	}
