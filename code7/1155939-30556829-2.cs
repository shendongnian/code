    public interface ICustomControl
    {
            void Clear();
            FieldType FieldType { get; set; }
            bool DocumentLoaded { get; set; }
            void Initialize(DocumentContainer container);
    }
    public interface ICustomControlWithText 
    {
            string Text { get; set; }
            ErrorProvider ErrorProvider { get; set; }
            List<IValidation> Validations { get; set; }
            void Validate(ErrorProvider provider);
    }
       
    class CustomCheckbox : CheckBox, ICustomControl    {  ...  }
    class CustomTextbox : TextBox, ICustomControl, ICustomControlWithText      {...}
     public static void Initialize(Control control, DocumentContainer container, ErrorProvider provider)
        {
            var custom = control as ICustomControl;
            if (control == null)
                return;
            custom.DocumentLoaded = true;
            custom.Initialize(container);
            var controlWithTextBase = control as ICustomControlWithText;
            if (controlWithTextBase != null)
                controlWithTextBase.Validate(provider);
            foreach (Control subControl in control.Controls)
                Initialize(subControl, container, provider);
        }
