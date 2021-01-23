    string description = {yourdataobject}.Description;
    string errorMessage;
    int minValue = {yourdataobject}.MinimumValue; //Replace int with the desired data type
    CompareValidator valueMinValidator = ((CompareValidator){containername}).FindControl("ValueMinValidator");
    errorMessage = string.Format("{0} below minimum {1}", description, {localize minValue here});
    valueMinValidator.ErrorMessage = errorMessage;
    valueMinValidator.ToolTip = errorMessage;
