    ALTER PROCEDURE [dbo].[SP_COUNTPOLICYMEMBERS]
    AS
    BEGIN        
    SELECT  [DateID]
    ,[PolicyNumber]
    ,[Name]
    ,[PolicyName]
    ,[InceptionDate]
    ,[Active]   
    FROM [dbo].[tblPolicy] WHERE [Active]=1
    END
    protected void btnTerminate_Click(object sender, EventArgs e)
    {
    if (Session["DateID"] != null)
    {
        List<tblPolicy> _PolicyMemberList = _dc.tblPolicies.Where(a => a.DateID == int.Parse(Session["DateID"].ToString())).ToList();
        if (_PolicyMemberList != null)
        {
            if (_PolicyMemberList.Count() > 0)
            {
                foreach (tblPolicy _PolicyMember in _PolicyMemberList)
                {
                    _PolicyMember.Active = false;
                }
                _dc.SubmitChanges();
                lblresults.Text = "Confirmation: Member has been terminated/deleted successfully.!";
                lblTotal.Text = "Total Members Captured : " + CountMembersCaptured();
            }
        }
    }
    }
