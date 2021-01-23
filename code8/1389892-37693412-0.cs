    public enum Transaction
    {
      LOCK = 0x01,
      UNLOCK
    };
    private static string getTransactionDescription(Transaction transaction, string data = "")
        {
            string result = "";
     switch (transaction)
     {
       case Transaction.UNLOCK:
       case Transaction.LOCK:
        var slot = ByteOperation.reverse4ByteBitPattern(data.Substring(32, 64));
        for (int i = 8 - 1; i >= 0; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((Convert.ToInt32(ByteOperation.ToggleEndian_4Bytes(slot.Substring(i * 8, 8)), 16) & (1 << j)) > 0)
                {
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        result += ", ";
                    }
                    result += "Slot " + (((7 - i) * 8) + j + 1).ToString("D3");
                }
            }
        }
        break;
    }
    return result;
