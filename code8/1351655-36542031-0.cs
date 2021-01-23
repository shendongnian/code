    public class TestInterceptor : EmptyInterceptor {
    
        private int updates;
        private int creates;
        private int loads;
    
        public override void OnDelete(object entity,
                                      object id,
                                      object[] state,
                                      string[] propertyNames,
                                      IType[] types)
        {
        }
    
        public override bool OnFlushDirty(object entity, 
                                          object id, 
    				      object[] currentState,
    				      object[] previousState, 
    				      string[] propertyNames,
    				      IType[] types) 
        {
        }
    
        public override bool OnLoad(object entity, 
                                    object id, 
    				object[] state, 
    				string[] propertyNames, 
    				IType[] types)
        {
        }
    
        public override bool OnSave(object entity, 
                                    object id, 
    				object[] state, 
    				string[] propertyNames, 
    				IType[] types)
        {
        }
    
        public override void AfterTransactionCompletion(ITransaction tx)
        {
            if ( tx.WasCommitted ) {
            }
        }
    }
