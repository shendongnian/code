    public class TransactionInquiryExt : PXGraphExtension<TransactionInquiry>
    {
        public void TranFilter_RowSelected(PXCache cache, PXRowSelectedEventArgs e, PXRowSelected baseInvoke)
        {
            if (baseInvoke != null)
                baseInvoke(cache, e);
            PX.Objects.PM.TransactionInquiry.TranFilter row = e.Row as PX.Objects.PM.TransactionInquiry.TranFilter;
            if (row == null) return;
            PXUIFieldAttribute.SetDisplayName<PMTran.description>(Base.Transactions.Cache,
                row.ProjectID.HasValue ? "Description for Project Tran" : "Description");
        }
    }
