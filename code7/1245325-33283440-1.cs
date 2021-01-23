     @for (int i = 0; i < Model.ListofModCls.Count; i++)
     {
	    if (Model.ListofModCls[i].IsColumn1Visible)
    	{
		    <td>
           		@Html.DisplayFor(d => Model.ListofModCls[i].Column1Name)
           		@Html.HiddenFor(d => Model.ListofModCls[i].IsColumn1Visible)
        	</td>
	    }
	.
	.
	.
	.
	.
	    if (Model.ListofModCls[i].IsColumn50Visible)
    	{
		    <td>
           		@Html.DisplayFor(d => Model.ListofModCls[i].Column50Name)
           		@Html.HiddenFor(d => Model.ListofModCls[i].IsColumn50Visible)
        	</td>
	     }
    }
