    for (rowCnt = 1; rowCnt <= range.Rows.Count; rowCnt++)
            {
                
                string Charity = (string)(range.Cells[rowCnt, 1] as Excel.Range).Value; 
                string Country = (string)(range.Cells[rowCnt, 2] as Excel.Range).Value; 
                System.Console.WriteLine(Charity + " --- " + Country);
            }
