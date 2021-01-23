    public static class ResourceLoader
    {
        public static void ChangeLanguage(System.Windows.Forms.Form form, System.Globalization.CultureInfo language)
        {
            var resources = new System.ComponentModel.ComponentResourceManager(form.GetType());
            foreach (Control control in form.Controls)
            {
                resources.ApplyResources(control, control.Name, language);
            }
            // These may not be needed, check if you need them.
            Thread.CurrentThread.CurrentUICulture = language;
            Thread.CurrentThread.CurrentCulture = language;
        }
    }
