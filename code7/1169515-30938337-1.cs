        private static IEnumerable<FactoryOrder> Merge(IEnumerable<FactoryOrder> orders)
        {
            var enumerator = orders.OrderBy(x => x.OrderNo).GetEnumerator();
            FactoryOrder previousOrder = null;
            FactoryOrder mergedOrder = null;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (mergedOrder == null)
                {
                    mergedOrder = new FactoryOrder(current.Text, current.OrderNo);
                }
                else
                {
                    if (current.OrderNo == previousOrder.OrderNo + 1)
                    {
                        mergedOrder.Text += current.Text;
                    }
                    else
                    {
                        yield return mergedOrder;
                        mergedOrder = new FactoryOrder(current.Text, current.OrderNo);
                    }
                }
                previousOrder = current;
            }
            if (mergedOrder != null)
                yield return mergedOrder;
        }
