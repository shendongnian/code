    using PX.Data;
    using PX.Data.EP;
    
    namespace PX.Objects.GL
    {
    
        public class JournalEntry_Extension : PXGraphExtension<JournalEntry>
        {
            [PXDBString(15, IsUnicode = true, IsKey = true, InputMask = ">CCCCCCCCCCCCCCC")]
            [PXDefault()]
            [PXUIField(DisplayName = "Batch Number", Visibility = PXUIVisibility.SelectorVisible)]
            [BatchModule.Numbering()]
            [PXFieldDescription]
            [PXSelector(
                typeof(Search<Batch.batchNbr, 
                                    Where<Batch.module, 
                                            Equal<Current<Batch.module>>, 
                                        And<Batch.draft, 
                                            Equal<False>>>, 
                                    OrderBy<Desc<Batch.batchNbr>>>),
                typeof(Batch.module),
                typeof(Batch.batchNbr),
                typeof(Batch.ledgerID),
                typeof(Batch.finPeriodID),
                typeof(Batch.status),
                typeof(Batch.debitTotal),
                typeof(Batch.creditTotal),
                typeof(Batch.curyID),
                typeof(Batch.createdByID),
                typeof(Batch.description),
                Filterable = true
            )]
            protected virtual void Batch_BatchNbr_CacheAttached(PXCache cache)
            {
    
            }
        }
    }
