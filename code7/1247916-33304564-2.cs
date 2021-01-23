	protected void Page_Unload(object sender, System.EventArgs e) {
	    'REMOVE OLD REPORT DOC FROM SESSION
        'if you are having any problem with this code here then you may also move it to the NOT POSTBACK block in the Page_Load event.
		if (Session.Item("CRpt") != null) {
			Session.Remove("CRpt");
		}
		Session.Add("CRpt", rdoc);
	}
