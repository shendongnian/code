    //open actions
                try
                {
                    actionTest.ActionsOpen();
                    listaObj.Add("ActionsOpen()", "Passed ! ");
                    actionTest.Actions_header_remove_colls();
                    listaObj.Add("Actions_header_remove_colls()", "Passed ! ");
                    actionTest.Actions_click_insert_header();
                    listaObj.Add("Actions_click_insert_header()", "Passed !");
                }
                catch (Exception e) 
                {
                    validator = false;
                    MethodBase site = ex.TargetSite;
                    string methodName = site == null ? null : site.Name;
                    listaObj.Add(methodName, "Failed: " + e.Message);
                }
              
