    public void SetPrintTitleRows(int startRowIndex, int? endRowIndex = null)
            {
                var localSheetId = _localsheetId++;    //LocalSheetIds are 0-indexed.
    			
                var definedName = new DefinedName
                {
                    Name = "_xlnm.Print_Titles",
                    LocalSheetId = localSheetId,
                    Text = String.Format("\'{0}\'!${1}:${2}", _sheetName, startRowIndex, endRowIndex ?? startRowIndex)
                };
    
                if (_workbookPart.Workbook.DefinedNames == null)
                {
                    var definedNamesCol = new DefinedNames();
                    _workbookPart.Workbook.Append(definedNamesCol);
                }
    
                _workbookPart.Workbook.DefinedNames.Append(definedName);
            }
