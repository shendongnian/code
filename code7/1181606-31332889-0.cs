    List<RootAction_Visitor> visitors = new List<>();
    visitors[EnumRootAction.Type1] = new RootAction1_Visitor();
    visitors[EnumRootAction.Type2] = new RootAction2_Visitor();
    List<ChildAction_Element> elements = new List<>();
    elements[EnumChildAction.Ac1] = new ChildAction1_Element();
    elements[EnumChildAction.Ac2] = new ChildAction2_Element();
    elements[EnumChildAction.Ac3] = new ChildAction3_Element();
    public void doMyThing(EnumRootAction root, EnumChildAction child) {
        visitors[root].visit( elements[child] );
    }
    
    //=======================================================================
    // Visitors
    interface RootAction_Visitor {
        public visit(ChildAction1_Element childAction);
        public visit(ChildAction2_Element childAction);
        public visit(ChildAction3_Element childAction);
    }
    class RootAction1_Visitor implements RootAction_Visitor {
        public visit(ChildAction1_Element childAction) {
            // ... do something
        }
        public visit(ChildAction2_Element childAction) {
            // ... do something
        }
        public visit(ChildAction3_Element childAction) {
            // ... reject
        }
    }
    class RootAction2_Visitor implements RootAction_Visitor {
        public visit(ChildAction1_Element childAction1) {
            // ... do something
        }
        public visit(ChildAction2_Element childAction2) {
            // ... reject
        }
        public visit(ChildAction3_Element childAction3) {
            // ... do something
        }
    }
    
    //=======================================================================
    // Elements
    interface ChildAction_Element {
        public void accept(RootAction_Visitor visitor);
    }
    class ChildAction1_Element implements ChildAction_Element {
        public void accept(RootAction_Visitor visitor) { visitor.visit(this); }
    }
    class ChildAction2_Element implements ChildAction_Element {
        public void accept(RootAction_Visitor visitor) { visitor.visit(this); }
    }
    class ChildAction3_Element implements ChildAction_Element {
        public void accept(RootAction_Visitor visitor) { visitor.visit(this); }
    }
