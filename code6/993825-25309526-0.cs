        for (int k=clb_input.Items.Count-1; k >= 0; k--)
        {
            if (clb_input.GetItemChecked(k) == true)
            {
                q.Add(clb_input.Items[k].ToString());
                clb_input.Items.RemoveAt(k);
            }
            else { }
        }
        q.Sort();
        for (int t = 0; t < q.Count; t++)
        {
            clb_output.Items.Add(q[t].ToString());
        }
    }
