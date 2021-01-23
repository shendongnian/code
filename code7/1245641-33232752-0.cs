    public static void UpdateMemReasonSecond(int SerNoID, string sel ,Page page)
    {
       JobOutturn SerNo = new JobOutturn(SerNoID);
            SerNo.MemReasonSecond = sel;
            SerNo.MemDate = DateTime.Now;
            SerNo.MemUser = CurrentUser.Username;
            SerNo.Update();
    
            if (SerNo.MemReason == "" & SerNo.MemReasonSecond != "")
            {
              
                page.ClientScript.RegisterStartupScript(page.GetType(),"alert", "<script>alert('Please fill in first reason');</script>");
            }
        }        
