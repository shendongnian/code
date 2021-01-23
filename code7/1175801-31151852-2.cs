    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<TableDetails> lstDelItems = new List<TableDetails>();
        List<TableDetails> lstDetails = Session["ListView1Data"] as List<TableDetails>;
        EntityFrameworkModel entity = new EntityFrameworkModel();
        if (Session["DeletedItems"] != null)
        {
            lstDelItems = Session["DeletedItems"] as List<TableDetails>;
        }
        foreach (TableDetails det in lstDetails)
        {
            // Insert. For all the new entries, the ID value will be 0
            if (det.Id == 0)
            {
                entity.TableDetails.Add(det);                    
            }
            // Update. If ID exists in the db, its a modified data
            else if (entity.TableDetails.Any(d => d.Id == det.Id))
            {
                TableDetails detail = entity.TableDetails.First(d => d.Id == det.Id);
                detail.FirstName = det.FirstName;
                detail.LastName = det.LastName;
                detail.Column3 = det.Column3;
                detail.Column4 = det.Column4;
            }
                
            entity.SaveChanges();
        }
        // Delete.
        foreach (TableDetails det in lstDelItems)
        {
            TableDetails detail = entity.TableDetails.First(d => d.Id == det.Id);
            entity.TableDetails.Remove(detail);
            entity.SaveChanges();
        }
        LoadListView();
        Session["DeletedItems"] = null;
    }
