    foreach (Control a in Page.Master.Controls)
            {
                foreach (Control c in Master.Controls)
                {
                    if (c.UniqueID == "form1")
                    {
                        foreach (Control b in c.Controls)
                        {
                            if (b.UniqueID.Contains("header"))
                            {
                                b.Visible = false;
                            }
                        }
                    }
                }
            }
