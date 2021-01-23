        private bool SetBarcode(string text)
        {
                Excel._Worksheet sheet;
                sheet = (Excel._Worksheet)m_currentWorkbook.ActiveSheet;
                try
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(@"&""IDAutomationHC39M,Regular""&22(");
                    str.Append(text);
                    str.Append(")");
                    Excel.PageSetup setup;
                    setup = sheet.PageSetup;
                    try
                    {
                        setup.LeftFooter = str.ToString();
                    }
                    finally
                    {
                        RemoveReference(setup);
                        setup = null;
                    }
                }
                finally
                {
                    RemoveReference(sheet);
                    sheet = null;
                }
                return true;
        }
