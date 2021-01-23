        /// <summary>
        /// Convert the string to a CSV field,
        /// enclosed in quotes to protect comma's in the field,
        /// with the quotes in the field escaped,
        /// and the separation value added
        /// </summary>
        /// <param name="Field"></param>
        /// <returns></returns>
        public static string CsvField(string Field)
        {
            //const string CsvDelim = ",";
            const string Quote = "\"";
            const string Quotes2 = "\"\"";
            string F = "";
            if (Field != null)
            {
                Field = CsvProcessNewline(Field);
                F = string.Format("{0}{1}{0}", Quote, Field.Replace(Quote, Quotes2));
            }
            return F;
        }
        /// <summary>
        /// Convert the number to a CSV field,
        /// enclosed in quotes to protect comma's in the field,
        /// with the quotes in the field escaped,
        /// and the separation value added
        /// </summary>
        /// <param name="Field"></param>
        /// <returns></returns>
        public static string CsvField(int Field)
        {
            return CsvField(string.Format("{0}", Field));
        }
        /// <summary>
        /// Convert the date to a CSV field
        /// </summary>
        /// <param name="Field"></param>
        /// <returns></returns>
        public static string CsvField_Date(DateTime Field)
        {
            return CsvField(string.Format("{0:yyyy-MM-ddTHH:mm:ss}", Field));
        }
        /// <summary>
        /// Newlines in a quoted CSV text field should not be a problem,
        /// but some systems can only handle this if CR+LF is replaced by CR or LF.
        /// </summary>
        /// <param name="Field"></param>
        /// <returns></returns>
        public static string CsvProcessNewline(string Field)
        {
            const string NL = "\n";
            //const string CR = "\r";
            const string CRNL = "\r\n";
            const string NLCR = "\n\r";
            Field = Field.Replace(CRNL, NL);
            Field = Field.Replace(NLCR, NL);
            return Field;
        }
