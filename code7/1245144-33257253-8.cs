    public class RepositoryItemCustomEdit1 : RepositoryItemPopupContainerEdit
    {
        #region Some default stuff for custom repository item (constructors, registration, etc).
        static RepositoryItemCustomEdit1() { RegisterCustomEdit1(); }
        public const string CustomEditName = "CustomEdit1";
        public RepositoryItemCustomEdit1() { }
        public override string EditorTypeName { get { return CustomEditName; } }
        public static void RegisterCustomEdit1()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(
                CustomEditName, 
                typeof(CustomEdit1), 
                typeof(RepositoryItemCustomEdit1),
            //For v13.2 you need to use custom ViewInfo class. So, here is CustomEdit1ViewInfo.
            //For v15.1 you can use the base PopupContainerEditViewInfo.
                typeof(CustomEdit1ViewInfo),
                new ButtonEditPainter(), 
                true, 
                img));
        }
        #endregion
        #region Hide base PopupContainerControl properties in designer.
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override PopupContainerControl PopupControl
        {
            get { return base.PopupControl; }
            set { base.PopupControl = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override int ActionButtonIndex
        {
            get { return base.ActionButtonIndex; }
            set { base.ActionButtonIndex = value; }
        }
        #region
        #region First PopupContainerControl properties
        public int DefaultActionButtonIndex { get; set; }
        public PopupContainerControl DefaultPopupControl { get; set; }
        #endregion
        #region Another PopupContainerControl properties
        public int DifferentActionButtonIndex { get; set; }
        public PopupContainerControl DifferentPopupControl { get; set; }
        #endregion
        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemCustomEdit1 source = item as RepositoryItemCustomEdit1;
                if (source == null) return;
                DefaultActionButtonIndex = source.DefaultActionButtonIndex;
                DefaultPopupControl = source.DefaultPopupControl;
                DifferentPopupControl = source.DifferentPopupControl;
                DifferentActionButtonIndex = source.DifferentActionButtonIndex;
            }
            finally
            {
                EndUpdate();
            }
        }
    }
