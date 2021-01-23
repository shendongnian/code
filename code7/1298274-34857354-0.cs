    if (request.Sorts.Any())
        {
            foreach (SortDescriptor sortDescriptor in request.Sorts)
            {
                if (sortDescriptor.SortDirection == ListSortDirection.Ascending)
                {
                    switch (sortDescriptor.Member)
                    {
                        case "OrderID":
                            orders= orders.OrderBy(order => order.OrderID);
                            break;
                        case "ShipAddress":
                            orders= orders.OrderBy(order => order.ShipAddress);
                            break;
                    }
                }
                else
                {
                    switch (sortDescriptor.Member)
                    {
                        case "OrderID":
                            orders= orders.OrderByDescending(order => order.OrderID);
                            break;
                        case "ShipAddress":
                            orders= orders.OrderByDescending(order => order.ShipAddress);
                            break;
                    }
                }
            }
        }
