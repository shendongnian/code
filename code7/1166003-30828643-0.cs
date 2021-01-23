    <script type="text/javascript">
    function PartialPostBackFinished(sender, args) {
        var updatePanels = args.get_panelsUpdated();
        for (i = 0; i < updatedPanels.length; i++) {
            //Do whatever needs to be triggered for each updated update panel
            InitializeControls(updatedPanels[i]);
        }
    }
    
    function InitializeControls(container) {
        $('.datepicker', container).datepicker(); //Initialise any date pickers
    }
    if (Sys != undefined) {
        //There's a ScriptManager on the page
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(PartialPostBackFinished);
        if (!prm.get_isInAsyncPostBack()) {
            //Trigger initialization for synchronous post back triggered outside updatepanels
            InitializeControls(document);
        }
    }
    else {
        //Trigger initialization for pages without ScriptManager
        InitializeControls(document);
    }
    </script> 
