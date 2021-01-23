    @{
        int Total = 0;
        foreach (OrderItem Item in Order.OrderItem.ToList())
        {
            <tr>
                <td>@Item.TotalPrice </td>
            </tr>
            Total += Convert.ToInt32(Item.TotalPrice);
        }
    }
