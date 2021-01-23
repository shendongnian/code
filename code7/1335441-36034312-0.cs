    protected override ValidatorResult Evaluate()
    {
      string controlValidationValue = this.ControlValidationValue;
      if (string.IsNullOrEmpty(controlValidationValue))
        return ValidatorResult.Valid;
      string pattern = this.Parameters["Pattern"];
      if (string.IsNullOrEmpty(pattern) || new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(controlValidationValue))
        return ValidatorResult.Valid;
      this.Text = this.GetText("The field \"{0}\" does not match the regular expression \"{1}\".", this.GetFieldDisplayName(), pattern);
      return this.GetFailedResult(ValidatorResult.Error);
    }
