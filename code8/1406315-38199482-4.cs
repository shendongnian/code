    var toUpdate = balances.Select(item => 
       {
            var thisQty = details.Where(x => x.Code == item.Code).Sum(x => x.QTY);
            var blnc = item.BLNC - thisQty;
            return new MyModel
            {
                BLNC = blnc,
                VAL = (blnc == 0) ? 0 : item.VAL - (thisQty * item.RATE),
                RATE = item.RATE,
                TABLE = "Orders"
            };
       }).ToList();
