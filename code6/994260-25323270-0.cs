            int y;
            if (clb_output.Items.Count != 0)
            {
                for (y = 0; y < q.Count; y++)
                {
                    if (!clb_output.Items.Contains(q[y].ToString()))
                    {
                        clb_output.Items.Add(q[y].ToString());
                    }
                }
            }
            else
            {
                for (int t = 0; t < q.Count; t++)
                    clb_output.Items.Add(q[t].ToString());
            }
