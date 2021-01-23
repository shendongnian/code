    public MyContext() {
            IObjectContextAdapter objectContextAdapter = (this as IObjectContextAdapter);
            objectContextAdapter.ObjectContext.ObjectStateManager.ObjectStateManagerChanged += ObjectStateManager_ObjectStateManagerChanged;
        }
        private void ObjectStateManager_ObjectStateManagerChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            // we are only interested in entities that
            // have been added to the state manager
            if (e.Action != CollectionChangeAction.Add)
                return;
            IObjectContextAdapter objectContextAdapter = (this as IObjectContextAdapter);
            var state = objectContextAdapter.ObjectContext.ObjectStateManager.GetObjectStateEntry(e.Element).State;
            // we are only interested in entities that
            // are unchanged (that is; loaded from DB)
            if (state != EntityState.Unchanged)
                return;
            OnObjectMaterialized(e.Element);
        }
        private void OnObjectMaterialized(object e) {
            if (e is ICryptographerUser) {
                //INJECT INSTANCE HERE
                (e as ICryptographerUser).Cryptographer = new Cryptographer();
            }      
        }
