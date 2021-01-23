    List<string> q = new List<string>();
    private void button_ekle_Click(object sender, EventArgs e)
    {
        for (int k=clb_input.Items.Count-1; k >= 0; k--)
        {
            if (clb_input.GetItemChecked(k) == true)
            {
                q.Add(clb_input.Items[k].ToString());
                clb_input.Items.RemoveAt(k);
            }
            else { }
        }
        q.Sort((p1,p2)=>((int)(p1.split(" ")[1])).CompareTo((int)(p2.split(" ")[1])));
        for (int t = 0; t < q.Count; t++)
        {
            clb_output.Items.Add(q[t].ToString());
        }
    }
