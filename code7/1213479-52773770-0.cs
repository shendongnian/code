    private void GetParentPageHiddenField()
        {
			System.Web.UI.WebControls.HiddenField ParenthiddenField = null;
            Control ctl = this.Parent;
            while (true)
            {
                ParenthiddenField = (System.Web.UI.WebControls.HiddenField)ctl.FindControl("ParentPageHiddenFieldID");
                if (ParenthiddenField == null)
                {
                    if (ctl.Parent == null)
                    {
                        return;
                    }
                    ctl = ctl.Parent;
                    continue;
                }
                break;
            }
			var parentHiddenFieldValue=ParenthiddenField.Value;
		}
