    public class CustomEdit1 : PopupContainerEdit
    {
        #region Some default staff for custom edit (constructors, registration, etc).
        //
        #endregion
        //Set the Properties.ActionButtonIndex value according to which button is pressed
        protected override bool IsActionButton(EditorButtonObjectInfoArgs buttonInfo)
        {
            Properties.ActionButtonIndex = Properties.Buttons.IndexOf(buttonInfo.Button);
            return
                Properties.ActionButtonIndex == Properties.DefaultActionButtonIndex ||
                Properties.ActionButtonIndex == Properties.DifferentActionButtonIndex;
        }
        //Set the Properties.PopupControl according to Properties.ActionButtonIndex value
        protected override void ActionShowPopup(EditorButtonObjectInfoArgs buttonInfo)
        {
            if (Properties.ActionButtonIndex == Properties.DefaultActionButtonIndex)
                Properties.PopupControl = Properties.DefaultPopupControl;
            else
                Properties.PopupControl = Properties.DifferentPopupControl;
            base.ActionShowPopup(buttonInfo);
        }
    }
