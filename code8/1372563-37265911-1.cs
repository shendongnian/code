    public class APInvoiceEntry_Extension:PXGraphExtension<APInvoiceEntry>
    {
        public override void Initialize()
        {
            PXDBStringAttribute.SetInputMask<APInvoice.docDesc>(Base.Document.Cache, ">CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC");
        }            
    }
