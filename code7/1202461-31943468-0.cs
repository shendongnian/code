    public static void UpdateDebrief(int ID, string ItemNo, int QtyDelivered, int QtyNOTDelivered, string Reason)
    {
        if (!(Session("DebriefCreated") != null && (bool) Session("DebriefCreated")))
        {
            Session("DebriefCreated") = true;
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
            deb.Create();
        }
    }
