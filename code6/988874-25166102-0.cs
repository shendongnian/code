            // Tell this page to use the wide setting on the master page
            Master.UseWideSetting = true;
            //Check to see if the user has permission
            CheckPageForPermission("Queue");
            base.SetActiveMenuItem(3);
            ucPager.PageChange += new EDDC.Controls.Pager.EmptyEventHandler(ucPager_PageChange);
            GenerateSearchQueryString();
            List<CAT.EDDC.Data.UserRole> roles = Common.GetCurrentUserRoles();
            foreach (CAT.EDDC.Data.UserRole r in roles)
            {
                if (r.AddOnRole == "PUB")
                {
                    bool exists = false;
                    foreach (ListItem item in drpDateView.Items)
                    {
                        if (item.Value == "Extended")
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        // Add the item if permissions are correct 
                        drpDateView.Items.Insert(1, new ListItem("Extended", "EXTENDED"));
                    }
                    if (Extended)
                    {
                        LoadQueue("EXTENDED");
                    }
                    else
                    {
                        LoadQueue("CURRENT");
                    }
                }
            }
            if (!Page.IsPostBack)
            {
                if (AutoSearch)
                {
                    if (DrawingId != null)
                    {
                        AutoSearchPopulate();
                    }
                    /*------------------------------------------------------
                     * Bug 3209 Drawing Number Included
                     * 
                     * Resolution - Removed the Call to Populate the search.
                     * Also removed the Property for Drawing Number
                     * -----------------------------------------------------*/
                    qsSearch.Collapsed = false;
                    lblUsername.Text = Common.GetCurrentUserRec().ScreenName;
                    popupWindow.UpdatePanelToRefresh = upnlRequest.ClientID;
                    ResetPager();
                    //List<CAT.EDDC.Data.UserRole> roles = Common.GetCurrentUserRoles();
                    if (!drpDateView.Items.Contains(new ListItem("Extended", "Extended")))
                        drpDateView.Items.Insert(1, new ListItem("Extended", "Extended"));
                    drpDateView.SelectedValue = "EXTENDED";
                    LoadQueue("Extended");
                }
                else if (RefreshSearch)
                {
                    LoadSearchParameters();
                    LoadQueueFromQueryString();
                }
                else
                {
                    lblUsername.Text = Common.GetCurrentUserRec().ScreenName;
                    popupWindow.UpdatePanelToRefresh = upnlRequest.ClientID;
                    ResetPager();
                    //List<CAT.EDDC.Data.UserRole> roles = Common.GetCurrentUserRoles();
                    if (Extended)
                    {
                        LoadQueue("EXTENDED");
                    }
                    else
                    {
                        LoadQueue("CURRENT");
                    }
                }
            }
        }
