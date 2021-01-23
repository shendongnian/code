    public class CustomDateValidator : JsonValidator
    {
        public override void Validate(JToken value, JsonValidatorContext context)
        {
            if (value.Type != JTokenType.String)
            {
                return;
            }
            var stringValue = value.ToString();
            DateTime date;
            if (!DateTime.TryParseExact(stringValue, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out date))
            {
                context.RaiseError($"Text '{stringValue}' is not a valid date.");
            }
        }
        public override bool CanValidate(JSchema schema) => schema.Format == "custom-date";
    }
