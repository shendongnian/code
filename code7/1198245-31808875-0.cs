    protected void btnSave_Click(object sender, EventArgs e)
        {
    
        if(liDelivery.Attributes["active"].ToString() == "false") return;
        string Note = Job.Compare(oldJob, new Job(int.Parse(Request.QueryString["JobID"])), Mod);
                                    JobNote modNote = new JobNote
                                    {
                                        JobID = job.ID,
                                        Company_ID = CurCompID,
                                        Date = DateTime.Now,
                                        Time = DateTime.Now,
                                        Note = Note,
                                        CreatedBy = CurrentUser.UserID,
                                        CreatedByName = CurrentUser.Username,
                                        NoteType = 1
                                    };
                                    modNote.Create();
    }
