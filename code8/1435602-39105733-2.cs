    public void OnMouseMove(object sender, MouseEventArgs e)
    {
            int currentindex;
            var result = sender as ListBoxItem;
            for (int i = 0; i < lb.Items.Count; i++)
            {
                if ((MyList.Items[i] as ListBoxItem).Content.ToString().Equals(result.Content.ToString()))
                {
                    currentindex = i;
                    break;
                }
            }
    }
