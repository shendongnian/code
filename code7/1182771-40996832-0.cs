        public static int LastRowIndex(this ISheet aExcelSheet)
        {
            IEnumerator rowIter = aExcelSheet.GetRowEnumerator();
            return rowIter.MoveNext()
            ? aExcelSheet.LastRowNum
            : -1;
        }
        public static int RowsSpanCount(this ISheet aExcelSheet)
        {
            return aExcelSheet.LastRowIndex() + 1;
        }
        public static int PhysicalRowsCount(this ISheet aExcelSheet )
        {
            if (aExcelSheet == null)
            {
                return 0;
            }
            int rowsCount = 0;
            IEnumerator rowEnumerator = aExcelSheet.GetRowEnumerator();
            while (rowEnumerator.MoveNext())
            {
                ++rowsCount;
            }
            return rowsCount;
        }
