     protected void Page_Load(object sender, EventArgs e)
                { 
                   if (Request["__EVENTARGUMENT"] != null && Request["__EVENTARGUMENT"] == "lstdbclick")
                    {
                       //your popup code here
                    }
                    lstitem.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(lstitem, "lstdbclick"));
                }
