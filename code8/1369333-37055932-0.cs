    var remaining = destination - total;
    for (int i = 0; remaining > 0 && i < quantityList.Count; i++) {
        var quantity = quantityList[i];
        // Avoid crashes on zero quantity
        if (quantity == 0) {
            continue;
        }
        // We cannot assign more than quantity * 0.05
        var toAssign = Math.Min(remaining, quantity * 0.05);
        remaining -= toAssign;
        // Split the amount being assigned among the items
        priceList[i] += toAssign / quantity;
    }
    if (remaining > 0) {
        Console.WriteLine("Unable to distribute {0:C}", remaining);
    }
