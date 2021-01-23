    using System.Windows.Forms;
    public static class ErrorHelper
    {
        public static void SetError(Form form, string controlName, string errorProviderName, string errorMessage)
        {
            var textBox = GetControl<TextBox>(form, controlName);
            if (textBox != null)
            {
                textBox.Text = errorMessage;
            }
            // If you create an ErrorProvider control by code
            // do not forget to add it to the form controls collection
            // by calling this.Controls.Add(errorProvider); in the form class
            // otherwise, it will not be found this way.
            var errorProvider = GetControl<ErrorProvider>(form, controlName);
            if (errorProvider != null)
            {
                errorProvider.Icon = Properties.Resources.err;
            }
        }
        private static T GetControl<T>(Form form, string controlName) where T : Control
        {
            foreach (object control in form.Controls)
            {
                var ctl = control as Control;
                if (ctl != null && String.Equals(ctl.Name, controlName))
                    return ctl as T;
            }
        }
    }
