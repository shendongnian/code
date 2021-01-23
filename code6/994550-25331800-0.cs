    public void SetFormFieldValue(HtmlControl control, object value)
    {
        string controlValue = value == null ? null : value.ToString();
        string tagName = control.TagName.ToLower();
        string fieldType = null;
        switch (tagName)
        {
            case "select":
                // The concrete Coded UI Test class I want to interact with
                HtmlComboBox select = new HtmlComboBox();
                // Make the `select` object reference the same element as `control`
                select.CopyFrom(control);
                // Set the value on the dropdown list
                select.SelectedItem = controlValue;
                break;
            case "textarea":
                HtmlTextArea textarea = new HtmlTextArea();
                textarea.CopyFrom(control);
                textarea.Text = controlValue;
                break;
            ...
        }
    }
