        public IEnumerable<MyOrderControl.Order> GetOrders()
        {
            foreach (var order in flowLayoutPanel1.Controls.OfType<MyOrderControl>())
            {
                yield return order.GetFilledOrder();
            }
        }
