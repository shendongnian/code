        public void AcquireOrders()
        {
            var form = new Form1();
            if (form.ShowDialog() != DialogResult.OK)
                return;
            foreach (var order in form.GetOrders())
            {
                System.Diagnostics.Debug.Print("Order: {0} Qty={1}",
                   order.Name, order.Quantity);
            }
        }
