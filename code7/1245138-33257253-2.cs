    public class RepositoryItemCustomEdit1 : RepositoryItemPopupContainerEdit
    {
        #region Some default stuff for custom repository item (constructors, registration, etc).
        //
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
