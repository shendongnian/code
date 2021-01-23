                foreach (Microsoft.Office.Interop.Word.Table oTable in wordDocument.Tables)
                {
                    oTable.AllowPageBreaks = false;                    
                    oTable.Rows.AllowBreakAcrossPages = 0;                    
                }
