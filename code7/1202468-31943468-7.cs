    public static void UpdateDebrief(int ID, string ItemNo, int QtyDelivered, int QtyNOTDelivered, string Reason)
    {
        if (Session["Debrief"] == null)
        {
            JobDebrief deb = new JobDebrief
            {
                JobID = ID,
                ItemNo = "",
                QtyDelivered = 0,
                QtyNotDelivered = 0,
                DbriefReason = "",
                DbriefDate = DateTime.Now,
                DbriefedBy = CurrentUser.UserID
            };
            Session["Debrief"] = deb;
            deb.Create();
        }
    }
