    public Boolean setSectionTickSign(decimal Trans_ID, decimal Job_ID, string SectioName)
    {
        string sectionames = "";
        try
        {
            var empQuery = r2ge.Transcription_Master.Where(l => l.Transcription_Id == Trans_ID && l.Entity_Id == Job_ID).ToList();
            foreach (Transcription_Master Trans_Mastrr in empQuery)
            {
                if (empQuery.Count == 0)
                {
                    if (sectionames == "")
                    {
                        Trans_Mastrr.Completed_Trans_Sections = SectioName;
                    }
                }
                else
                {
                    Trans_Mastrr.Completed_Trans_Sections = Trans_Mastrr.Completed_Trans_Sections + "," + SectioName;
                }
            }
            int sc = r2ge.SaveChanges();
        }
