    public class ARInvoicePXExt : PXCacheExtension<ARInvoice>
    {
        #region UsrAmountToWords
        public abstract class usrAmountToWords : IBqlField { }
       [PX.Objects.AP.ToWords(typeof(ARInvoice.curyOrigDocAmt))]
        public virtual string UsrAmountToWords { get; set; }
        #endregion
    }
