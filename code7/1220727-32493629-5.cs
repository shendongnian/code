        [System.Runtime.InteropServices.ComVisible(true)]
        public static String GetName(Type enumType, Object value)
        {
            if (enumType == null)
                throw new ArgumentNullException("enumType");
            Contract.EndContractBlock();
 
            return enumType.GetEnumName(value);
        }
