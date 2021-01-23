    public void GetBreadcrumbs(Item ParentItem)
            {
                List<BredCrumbDetails> lstBreadCrumbs = new List<BredCrumbDetails>();
                string strcurrenttitle = ParentItem.Name;
                Item currentitem = ParentItem;
                int i = 0;
                while (currentitem != null)
                {
                    var ItemTemplateid = currentitem.TemplateID.ToString();
                    var FolderTemplateId = "{}";
                    if (ItemTemplateid != FolderTemplateId) //here we are removing folders
                    {
                        BredCrumbDetails bcDetails = new BredCrumbDetails();
                        if (i == 0)
                        {
                            bcDetails.BCPageLink = null;
                            bcDetails.Title = currentitem.Name;
                            bcDetails.IsVisible = true;
                            lstBreadCrumbs.Add(bcDetails);
                        }
                        else
                        {
                            bcDetails.BCPageLink = currentitem.Paths.FullPath;
                            bcDetails.Title = currentitem.Name;
                            bcDetails.IsVisible = true;
                            lstBreadCrumbs.Add(bcDetails);
    
                        }
                        i++;
                        if (currentitem.Name == ("Home"))
                        {
    
                            break;
                        }
                        currentitem = currentitem.Parent;
                    }
                    else
                    {
                        i++;
                        currentitem = currentitem.Parent;
                    }
                }
    
                lstBreadCrumbs.Reverse();
                rptCrumbs.DataSource = lstBreadCrumbs;
                rptCrumbs.DataBind();
    
            }
