    protected void btnAssociateProjects_Click(object sender, EventArgs e) 
    {
        List < int > lstCorpProjAssoc = new List < int > ();
        foreach(GridViewRow gvRow in gvProjects.Rows) 
        {
            if (((CheckBox) gvRow.FindControl("cbInsert")).Checked) 
            {
                int cID = Convert.ToInt32(((Label) gvRow.FindControl("lblProjectID")).Text);
                lstCorpProjAssoc.Add(cID);
            }
        }
        foreach(int pstr in lstCorpProjAssoc) 
        {
            DALSectionAccessData ap = new DALSectionAccessData(connString);
            ap.AssociateCorpToProj(pstr, _cID);
    
        }
    }
