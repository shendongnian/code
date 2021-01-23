    public abstract class DynamicMetaObjectWrapper : DynamicMetaObject
    {
        protected DynamicMetaObjectWrapper(DynamicMetaObject metaObject)
                : base(metaObject.Expression, metaObject.Restrictions, metaObject.Value)
        {
            BaseMetaObject = metaObject;
        }
        public DynamicMetaObject BaseMetaObject { get; }
    
        public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg) => BaseMetaObject.BindBinaryOperation(binder, arg);
        public override DynamicMetaObject BindConvert(ConvertBinder binder) => BaseMetaObject.BindConvert(binder);
        public override DynamicMetaObject BindCreateInstance(CreateInstanceBinder binder, DynamicMetaObject[] args) => BaseMetaObject.BindCreateInstance(binder, args);
        public override DynamicMetaObject BindDeleteIndex(DeleteIndexBinder binder, DynamicMetaObject[] indexes) => BaseMetaObject.BindDeleteIndex(binder, indexes);
        public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder) => BaseMetaObject.BindDeleteMember(binder);
        public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes) => BaseMetaObject.BindGetIndex(binder, indexes);
        public override DynamicMetaObject BindGetMember(GetMemberBinder binder) => BaseMetaObject.BindGetMember(binder);
        public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args) => BaseMetaObject.BindInvoke(binder, args);
        public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args) => BaseMetaObject.BindInvokeMember(binder, args);
        public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value) => BaseMetaObject.BindSetIndex(binder, indexes, value);
        public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value) => BaseMetaObject.BindSetMember(binder, value);
        public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder) => BaseMetaObject.BindUnaryOperation(binder);
        public override IEnumerable<string> GetDynamicMemberNames() => BaseMetaObject.GetDynamicMemberNames();
    }
