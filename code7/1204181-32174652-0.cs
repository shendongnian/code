    [WebMethod]
    public static string UpdateSerialQtyRcvdUserControl(int SerNoID, int QtyRcvd)
    {
        return JobDeliveryDebrief.UpdateSerialQtyRcvd(SerNoID, QtyRcvd);
    }
    
