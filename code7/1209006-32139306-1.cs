        private static CellRange GetCellRange(string sReference, string sWorkbookName)
        {
            if (string.IsNullOrWhiteSpace(sReference))
                return null;
            sReference = sReference.Replace("=" + sWorkbookName + "!", string.Empty);
            sReference = sReference.Replace("$", string.Empty);
            string sColumn = string.Empty;
            string sRow = string.Empty;
            for (int i = 0; i < sReference.Length; i++)
            {
                if (char.IsDigit(sReference[i]))
                    sRow += sReference[i];
                else
                    sColumn += sReference[i];
            }
            int iRow = Convert.ToInt16(sRow) -1;
            int iCol = GetColIndex(sColumn);
            if (iRow >= 0 && iCol >= 0)
                return new CellRange(iRow, iCol,iRow,iCol);
            else
                return null;
        }
        //accepting up to AZ
        private static int GetColIndex(string sReference)
        {
            if (sReference.Length > 1)
            {
                int x = (int)sReference[1];
                return 25 + ((int)sReference[1] - 65);//25 as 26 letters in alphabet -1 (start from 0)
            }
            return (int)sReference[0] - 65;
        }
