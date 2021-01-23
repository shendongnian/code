    XElement[] GetAssessments()
    {
        var result = new List<XElement>();
        for (int i = 0; i < numericUpDownNoOfAssessments.Value; i++)
        {
            result.Add(new XElement("Assessment Type", (comboBoxAssessments[i] as ComboBox).Text));
            result.Add(new XElement("Assessment Grade", ""));
            result.Add(new XElement("Assessment Weighting", ""));
        }
        return result.ToArray();
    }
