    void SetIndexedProperty(Person person, int propertyIndex, string value)
    {
        switch (propertyIndex)
        {
        case firstNameColumn:
            person.FirstName = value;
            break;
        case lastNameColumn:
            person.LastName = value;
            break;
        // etc.
        }
    }
    void InitializeFromCell(Worksheet worksheet, int rowIndex)
    {
        for (int columnIndex = 1; columnIndex <= numberOfColumns; columnIndex++)
        {
            SetIndexedProperty(person, columnIndex, worksheet.Cells[rowIndex, columnIndex].Text);
        }
    }
