    // Provides your validation statuses.
    public enum ControlValidation
    {
        Ok,
        NotOk
    }
    
    // Provides a contract whereby your controls implement a validation property, indicating their status.
    public interface IValidationControl
    {
        ControlValidation ValidationStatus { get; private set; }
    }
    
    // An example of the interface implementation...
    public class TextBox : System.Windows.Forms.TextBox, IValidationControl
    {
        public ControlValidation ValidationStatus { get; private set; }
    
        ...
    
        protected override void OnTextChanged(EventArgs e)
        {
            ValidationStatus = ControlValidation.Ok;
        }
    }
