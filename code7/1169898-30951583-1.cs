        if (Session["Selected"] != null)
        {
            for (int i = 0; i < this.Menu1.Items.Count; i++)
            {
                if (this.Menu1.Items[i].Text == Session["Selected"].ToString())
                {
                    this.Menu1.Items[i].Selected = true;
                }
            }
        }
    }
