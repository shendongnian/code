    protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
             Button submitButton = new Button();
             submitButton.CausesValidation = true;
             submitButton.Click += submitButton_Click;
             nicknameTextBox.ID = "nickname";
             firstNameTextBox.ID = "firstname";
             fieldValidatorInitialValue.ControlToValidate = firstNameTextBox.ID;
           }
        }
