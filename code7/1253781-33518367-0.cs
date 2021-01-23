                       if (query.IsLinkQuery)
                        
                        {
                            var queryResults = query.RunLinkQuery();
                            lblQuery.Text = String.Format("Query Text Below | Query Type: {0}", "Linked Query");
                            label6.Text = String.Format("Total {0}", queryResults.Length);
                            foreach (WorkItemLinkInfo item in queryResults)
                            {
                                lstWorkItems.Items.Add(detailsOfTheSelectedProject.Store.GetWorkItem(item.TargetId).Id);
                            }
                        }
