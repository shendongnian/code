    LinkButton a = new LinkButton();
    a.Attributes.Add("ID", i.ToString()); 
    a.Click += Pagination_Click;
    a.Text = i.ToString();
    li.Controls.Add(a);
