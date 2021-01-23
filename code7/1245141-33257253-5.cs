    public class CustomEdit1 : PopupContainerEdit
    {
        #region Some default stuff for custom edit (constructors, registration, etc).
        //
        #endregion
        protected override bool IsActionButton(EditorButtonObjectInfoArgs buttonInfo)
        {
            int buttonIndex = Properties.Buttons.IndexOf(buttonInfo.Button);
            if (Properties.ActionButtonIndex == Properties.DefaultActionButtonIndex ||
                Properties.ActionButtonIndex == Properties.DifferentActionButtonIndex)
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
