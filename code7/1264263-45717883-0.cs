       public static string ValidateOpenXmlDocument(OpenXmlPackage pXmlDoc, bool throwExceptionOnValidationFail=false)
        {
            using (var docToValidate = pXmlDoc)
            {
                var validator = new DocumentFormat.OpenXml.Validation.OpenXmlValidator();
                var validationErrors = validator.Validate(docToValidate).ToList();
                var errors = new System.Text.StringBuilder();
                if (validationErrors.Any())
                {
                    var errorMessage = string.Format("ValidateOpenXmlDocument: {0} validation error(s) with document", validationErrors.Count);
                    errors.AppendLine(errorMessage);
                    errors.AppendLine();
                }
                foreach (var error in validationErrors)
                {
                    errors.AppendLine("Description: " + error.Description);
                    errors.AppendLine("ErrorType: " + error.ErrorType);
                    errors.AppendLine("Node: " + error.Node);
                    errors.AppendLine("Path: " + error.Path.XPath);
                    errors.AppendLine("Part: " + error.Part.Uri);
                    if (error.RelatedNode != null)
                    {
                        errors.AppendLine("Related Node: " + error.RelatedNode);
                        errors.AppendLine("Related Node Inner Text: " + error.RelatedNode.InnerText);
                    }
                    errors.AppendLine();
                    errors.AppendLine("==============================");
                    errors.AppendLine();
                }
                if (validationErrors.Any() && throwExceptionOnValidationFail)
                {
                    throw new Exception(errors.ToString());
                }
                if (errors.Length > 0)
                {
                    System.Diagnostics.Debug.WriteLine(errors.ToString());
                }
                return errors.ToString();
            }
