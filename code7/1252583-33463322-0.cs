    public static class EmailFactory
            {
                public static string ParseTemplate<T>(T model, string templatesPath, EmailType emailType)
                {
                    string templatePath = Path.Combine(templatesPath, string.Format("{0}.cshtml", emailType));
                    string content = templatePath.ReadTemplateContent();
    
                    return Razor.Parse(content, model);
                }
            }
