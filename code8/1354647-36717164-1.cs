    protected void Page_PreRender(object sender, EventArgs e)
    {
        switch ((REQUEST_PHASE)this.CurrentPhaseID)
        {
            case REQUEST_PHASE.RECORDS:
            {
                Page.ClientScript.RegisterClientScriptInclude(
                    typeof(REQUEST_PHASE), "MoveFocusOnChange", 
                    "~/scripts/moveFocusOnChange.js");
                break;
            }
        }
    }
