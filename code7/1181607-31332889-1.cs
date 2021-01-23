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
    abstract class RootAction_Visitor {
        public void visit(ChildAction1_Element childAction) { /*.. reject by default ...*/ }
        public void visit(ChildAction2_Element childAction) { /*.. reject by default ...*/ }
        public void visit(ChildAction3_Element childAction) { /*.. reject by default ...*/ }
    }
    class RootAction1_Visitor : RootAction_Visitor {
        public override void visit(ChildAction1_Element childAction) {
            // ... do something
        }
        public override void visit(ChildAction2_Element childAction) {
            // ... do something
        }
    }
    class RootAction2_Visitor : RootAction_Visitor {
        public override void visit(ChildAction1_Element childAction1) {
            // ... do something
        }
        public override void visit(ChildAction3_Element childAction3) {
            // ... do something
        }
    }
    
    //=======================================================================
    // Elements
    interface ChildAction_Element {
        void accept(RootAction_Visitor visitor);
    }
    class ChildAction1_Element : ChildAction_Element {
        public override void accept(RootAction_Visitor visitor) { visitor.visit(this); }
    }
    class ChildAction2_Element : ChildAction_Element {
        public override void accept(RootAction_Visitor visitor) { visitor.visit(this); }
    }
    class ChildAction3_Element : ChildAction_Element {
        public override void accept(RootAction_Visitor visitor) { visitor.visit(this); }
    }
