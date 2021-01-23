    static readonly Action<Person, string>[] _propertyIndexers =
    {
        (person, value) => person.FirstName = value,
        (person, value) => person.LastName = value,
        // etc.
    }
    void InitializeFromCell(Worksheet worksheet, int rowIndex)
    {
        for (int columnIndex = 1; columnIndex <= numberOfColumns; columnIndex++)
        {
            _propertyIndexers[columnIndex - 1](person, worksheet.Cells[rowIndex, columnIndex].Text);
        }
    }
