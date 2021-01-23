                var orderIds = new[] {"3", "5"}.ToList();
                var ids = new[] { "1", "2", "3", "4", "5" }.ToList();
                var names = new[] { "1", "2", "3", "4", "5" }.ToList();
                
                foreach (var orderId in orderIds)
                {                
                    if (ids.Contains(orderId))
                    {
                        listBox1.Items.Add(names[ids.IndexOf(orderId)]);
                    }
                    else
                    {
                        listBox1.Items.Add("Not in the list");
                    }
                }
