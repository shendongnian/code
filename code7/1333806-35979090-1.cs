    Private Void ProcessQuantity()
    {
      int qtyAmount = -1;
      int.TryParse(QuantityText, out qtyAmount)
      if (qtyAmount > -1)
      {
       //Do Processing here
      }
      else
      {
        throw new InvalidArgumentException("Quantity is invalid");
      }
    }
