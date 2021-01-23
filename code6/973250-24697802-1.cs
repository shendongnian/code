    private static void WriteControlValuesToXml(XmlDocument document, XmlNode parentNode, Control currentControl)
    {
        // if current control is container, writing its children values
        if (currentControl.Controls.Count > 0)
        {
            var addedNode = AddNode(parentNode, currentControl.Name);
            foreach (Control childControl in currentControl.Controls)
                WriteControlValuesToXml(document, addedNode, childControl);
        }
        else
        {
            // if current control is not container, writing control values
            if (currentControl is CheckBox)
            {
                var checkBox = (CheckBox)control;
                AddNode(parentNode, currentControl.Name, "CheckBox", checkBox.Checked);
            }
            if (currentControl is TextBox)
            {
                var textBox = (TextBox)control;
                AddNode(parentNode, currentControl.Name, "TextBox", textBox.Text);
            }
            // ... other known controls
        }
    }
