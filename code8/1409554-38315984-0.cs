    foreach (BaseValidator error in this.Validators)
    {
        if (error.IsValid)
            continue;
        Panel_feedback.Controls.Add(new LiteralControl("<li><i class='fa-li fa fa-times-circle'></i>" + error.ErrorMessage + "</li>"));
        string failedControlID = error.ControlToValidate;
        // ...
    }
