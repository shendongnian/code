            var definedName = new DefinedName() { Name = "_xlnm.Print_Titles", Text = "\'Sheet Name\'!$2:$2", LocalSheetId = (UInt32) (_nextSheetId - 1) };       // Create a new range
            if (_workbookPart.Workbook.DefinedNames == null)
            {
             var definedNamesCol = new DefinedNames();
            _workbookPart.Workbook.Append(definedNamesCol);
            }
            _workbookPart.Workbook.DefinedNames.Append(definedName);                  // Add it to the collection
