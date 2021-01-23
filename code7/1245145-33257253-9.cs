    public class CustomEdit1 : PopupContainerEdit
    {
        #region Some default stuff for custom edit (constructors, registration, etc).
        static CustomEdit1() { RepositoryItemCustomEdit1.RegisterCustomEdit1(); }
        public CustomEdit1() { }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomEdit1 Properties { get { return base.Properties as RepositoryItemCustomEdit1; } }
        public override string EditorTypeName { get { return RepositoryItemCustomEdit1.CustomEditName; } }
        #endregion
        protected override bool IsActionButton(EditorButtonObjectInfoArgs buttonInfo)
        {
            int buttonIndex = Properties.Buttons.IndexOf(buttonInfo.Button);
            if (buttonIndex == Properties.DefaultActionButtonIndex ||
                buttonIndex == Properties.DifferentActionButtonIndex)
            {
                //Set the Properties.ActionButtonIndex value according to which button is pressed:
                Properties.ActionButtonIndex = buttonIndex;
                //Set the Properties.PopupControl according to which button is pressed:
                if (buttonIndex == Properties.DefaultActionButtonIndex)
                    Properties.PopupControl = Properties.DefaultPopupControl;
                else
                    Properties.PopupControl = Properties.DifferentPopupControl;
                return true;
            }
            return false;                
        }
    }
