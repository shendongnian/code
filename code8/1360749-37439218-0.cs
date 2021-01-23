    using System;
    using System.Collections.Generic;
    using PX.Data;
    using PX.Objects.AP;
    using PX.Objects.GL;
    using PX.Objects.CM;
    using PX.Objects.CS;
    using PX.Objects.IN;
    
    namespace SGLCustomizeProject
    {
    
    	public class ARRelaseProcessExtension : PXGraphExtension<APReleaseProcess>
    	{
    		public delegate List<APRegister> ReleaseDocProcDel(JournalEntry je, ref APRegister doc, PXResult<APInvoice, CurrencyInfo, Terms, Vendor> res, bool isPrebooking, out List<INRegister> inDocs);
    		[PXOverride]
    		public virtual List<APRegister> ReleaseDocProc(JournalEntry je, ref APRegister doc, PXResult<APInvoice, CurrencyInfo, Terms, Vendor> res, bool isPrebooking, out List<INRegister> inDocs, ReleaseDocProcDel del)
    		{
    			je.RowInserting.AddHandler<GLTran>((sender, e) =>
    			{
    				GLTran glTran = e.Row as GLTran;
    
    				APInvoice api = PXSelect<APInvoice, Where<APInvoice.refNbr, Equal<Required<GLTran.refNbr>>, And<APInvoice.docType, Equal<Required<GLTran.tranType>>>>>.Select(sender.Graph, glTran.RefNbr, glTran.TranType);
    				if (api != null && api.InvoiceNbr != null)
    				{
    					GLTranExtension glTex = PXCache<GLTran>.GetExtension<GLTranExtension>(glTran);
    					glTex.UsrInvoiceNbr = api.InvoiceNbr;
    				}
    			});
    			return del(je, ref doc, res, isPrebooking, out inDocs);
    		}
    	}
    }
