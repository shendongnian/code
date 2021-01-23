        private void PlaceOrder_Click(object sender, EventArgs e)
        {
            //new AreYouSure().Show();
            //this.Show();
            using (var obj = new Confirmation())
            {
                var list = new List<object>(MenuBox.Items.Count);
                foreach (var o in MenuBox.Items)
                {
                    list.Add(o);
                }
                obj.AddRange(list.ToArray());
                if (obj.ShowDialog(this) == DialogResult.OK)
                {
                    MenuBox.Items.Clear();
                    TotalBox.Items.Clear();
                    total.Items.Clear();
                    ordertotal = 0;
                }
            }
        }
