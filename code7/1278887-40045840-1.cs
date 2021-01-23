        /// <summary>
        /// Generic method which reads a column from the <paramref name="workSheetToReadFrom"/> sheet provided.<para />
        /// The <paramref name="dumpVariable"/> is the variable upon which the column to be read is going to be dumped.<para />
        /// The <paramref name="workSheetToReadFrom"/> is the sheet from which te column is going to be read.<para />
        /// The <paramref name="initialCellRowIndex"/>, <paramref name="finalCellRowIndex"/> and <paramref name="columnIndex"/> specify the length of the list to be read and the concrete column of the file from which to perform the reading. <para />
        /// Note that the type of data which is going to be read needs to be specified as a generic type argument.The method constraints the generic type arguments which can be passed to it to the types which implement the IConvertible interface provided by the framework (e.g. int, double, string, etc.).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dumpVariable"></param>
        /// <param name="workSheetToReadFrom"></param>
        /// <param name="initialCellRowIndex"></param>
        /// <param name="finalCellRowIndex"></param>
        /// <param name="columnIndex"></param>
        static void ReadExcelColumn<T>(ref List<T> dumpVariable, Excel._Worksheet workSheetToReadFrom, int initialCellRowIndex, int finalCellRowIndex, int columnIndex) where T: IConvertible
        {
            dumpVariable = ((object[,])workSheetToReadFrom.Range[workSheetToReadFrom.Cells[initialCellRowIndex, columnIndex], workSheetToReadFrom.Cells[finalCellRowIndex, columnIndex]].Value2).Cast<object>().ToList().ConvertAll(e => (T)Convert.ChangeType(e, typeof(T)));
        }
