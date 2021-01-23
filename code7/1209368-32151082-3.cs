	public partial class ActividadProyecto : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
			object dummy;
			
			// skip logic if "Validate" is not called from EF...
			if (validationContext.Items.TryGetValue("is_data_layer", out dummy))
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
	}
