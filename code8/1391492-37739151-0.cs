    List<TAB1> itemList = 
      context.TAB1.Join(
      context.TAB2, itm => itm.ItemCode, bcd => bcd.ItemCode, (itm, bcd) => new { ITM = itm, BCD = bcd })
                         .Where(i => i.ITM.ItemCode == (itemCode ?? i.ITM.ItemCode))
                         .Where(i => i.BCD.BcdCode.Contains(codeBars ?? i.BCD.BcdCode))
    .Select(i => i.ITM)
    .ToList();
