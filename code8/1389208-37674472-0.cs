    if (!String.IsNullOrEmpty(txtjournalname.Text))
    {
        Session["JournalBookName"] = txtjournalname.Text;
        Response.Redirect("Journal Entry.aspx");
    }
    else
    {
        Session["JournalBookName"] ="Untitled Journal";
        Response.Redirect("Journal Entry.aspx");
    }
