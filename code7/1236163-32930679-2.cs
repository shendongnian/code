     public int RevisionID
        {
            get
            {
                int revisionID = 0;
                int.TryParse(hdnRevisionID.Value, out revisionID);
                if (revisionID == 0)
                {
                    if (Request.QueryString["ProposalID"] != null)
                    {
                        if (int.TryParse(Request.QueryString["ProposalID"].ToString(), out revisionID))
                        {
                            hdnRevisionID.Value = revisionID.ToString();
                            return revisionID;
                        }
                    }
                }
                else
                {
                    return revisionID;
                }
                return revisionID;
            }
        }
