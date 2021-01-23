        /// <summary>
        /// This code is here to embeed the following libraries : 
        /// - DocumentFormat.Excel
        /// - ExcelNumberFormat
        /// - FastMember.Signed
        /// </summary>
        private static void EmbeedNeededLibraries()
        {
            Action<Type> noop = _ => { };
            var lib1 = typeof(DocumentFormat.OpenXml.OpenXmlAttribute);
            var lib2 = typeof(ExcelNumberFormat.NumberFormat);
            var lib3 = typeof(FastMember.ObjectAccessor);
            noop(lib1);
            noop(lib2);
            noop(lib3);
        }
