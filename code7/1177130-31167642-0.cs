    const int firstNameColumn = 1;
    const int lastNameColumn = 2;
    // etc.
    void InitializeFromCell(Worksheet worksheet, int rowIndex)
    {
        person.FirstName = worksheet.Cells[rowIndex, firstNameColumn].Text;
        person.LastName = worksheet.Cells[rowIndex, lastNameColumn].Text;
        // etc.
    }
