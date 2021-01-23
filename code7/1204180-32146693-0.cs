    public static void UpdateSerialQtyRcvd(int SerNoID, int QtyRcvd)
    {
         if (SerNo.QtyRcvd != 1)
         {
             if (SerNo.Reason == "")
             {
                 throw new Exception("Your message");
             }
         }
    }
