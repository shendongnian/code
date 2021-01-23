                    string[] tree = lblCategory.Text.Split(',');
                    for (int i = 0; i < tree.Length; i++)
                    {
                      
                        foreach (RadTreeNode t in rtCategory.GetAllNodes())
                        {                           
                            if (t.Value == tree[i])
                            {
                                t.Selected = true;
                            }
                        }
                      
                    }
                    rtCategory.ExpandAllNodes();
                }
