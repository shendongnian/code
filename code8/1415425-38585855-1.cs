        public void AddFilterAndOrder(string filter = "", string order = "", bool loadModel = false)
        {
            if (filter != "")
            {
                string[] items = filter.Split(';');
                foreach (string i in items)
                {
                    string[] pair = i.Split(',');
                    if (pair[1] == "")
                        filters.Remove(pair[0]);
                    else
                        if (filters.Keys.Contains(pair[0]))
                        filters[pair[0]] = pair[1];
                    else
                        filters.Add(pair[0], pair[1]);
                }
            }
            if (order != "")
            {
                string[] items = order.Split(';');
                foreach (string i in items)
                {
                    string[] pair = i.Split(',');
                    if (pair[1] == "")
                        orders.Remove(pair[0]);
                    else
                        if (orders.Keys.Contains(pair[0]))
                        orders[pair[0]] = pair[1];
                    else
                        orders.Add(pair[0], pair[1]);
                }
            }
            if (loadModel) LoadModel();
        }
