    public void RejectOrder(string rejectReason, int selectedNewOrderId, User user)
    {
        SFNewOrder sfNewOrder = mdbDataContext.SFNewOrders.FirstOrDefault(x => x.ID == selectedNewOrderId && !x.IsRejected);
        if (sfNewOrder != null)
        {
            sfNewOrder.IsRejected = true;                              
        }
        SFReject sfReject = new SFReject();
        sfReject.SFNewOrder = sfNewOrder; 
        sfReject.RejectReason = rejectReason;
        sfReject.RejectedDate = DateTime.Now;           
        sfReject.User= user;
        mdbDataContext.SFRejects.InsertOnSubmit(sfReject);
        mdbDataContext.SubmitChanges();
    }
