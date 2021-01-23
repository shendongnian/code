     private void ResetComboBoxes2(string[] comboboxes, Excel.Application xlApp)
        {
            Excel.Worksheet wksht = new Excel.Worksheet();
            for (int i = 0; i < comboboxes.Length; i++)
            {
                    string[] comboBoxesSplit = comboboxes[i].Split(':');
                    string sheetName = comboBoxesSplit[0].ToString();
                    wksht = xlApp.ActiveWorkbook.Worksheets[sheetName];
                    foreach (Excel.OLEObject oleobj in wksht.OLEObjects())
                    {
                        if (oleobj.progID == "Forms.ComboBox.1")//oleobj.Name.ToString() == oleObjName)
                        {
                            string cbName = oleobj.Name.ToString();
                            wksht.OLEObjects(cbName).Object.ListIndex = 0;
                        }
                    }
            }
        }
