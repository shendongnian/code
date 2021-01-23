    public class ExtraOrdinaryClass
    {
        public ExtraOrdinaryClass(Excel.Worksheet someGoodSheet)
        {
            tSheetName            = someGoodSheet.Name;  // you arguably don't need this (just read tDesignSheet.Name)          
            tDesignSheet          = someGoodSheet;
        }
    }
