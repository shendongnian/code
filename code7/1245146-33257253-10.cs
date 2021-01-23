    public class CustomEdit1ViewInfo : PopupContainerEditViewInfo
    {
        public CustomEdit1ViewInfo(RepositoryItem item) : base(item) { }
        public new RepositoryItemPopupBase Item { get { return base.Item as RepositoryItemCustomEdit1; } }
        //Show the pressed state when button is pressed or when popup is open.
        protected override bool IsButtonPressed(EditorButtonObjectInfoArgs info)
        {
            var hitObject = PressedInfo.HitObject as EditorButtonObjectInfoArgs;
            return
                (hitObject != null && hitObject.Button == info.Button) ||
                (IsPopupOpen && Item.ActionButtonIndex == info.Button.Index);
        }
    }
