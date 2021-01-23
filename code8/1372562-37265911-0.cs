          public class APInvoiceEntry_Extension:PXGraphExtension<APInvoiceEntry>
          {
            #region Event Handlers
            public override void Initialize()
          {
                    PXDBStringAttribute.SetInputMask<APInvoice.docDesc>(Base.Document.Cache, ">CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC");
          }
            #endregion
          }
