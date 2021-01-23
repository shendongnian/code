    while (rd.Read())
            {
                HyperLink link = new HyperLink();
                link.ID = "link" + i;
                link.Text = rd[0].ToString();//value read from the database becomes the text for linkbutton
                link.NavigateUrl = "Destination.aspx?linktext=" + rd[0].ToString();
                PlaceHolder1.Controls.Add(link);//adding the link to the placeholder
                i++;
    }
