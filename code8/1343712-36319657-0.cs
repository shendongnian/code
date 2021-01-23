     protected void btnBookmark_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;      
        GridViewRow row = (GridViewRow)b.NamingContainer;
        var ProgramID = row.FindControl("lblProgramID") as Label;
        string stringProgramID = ProgramID.Text;      
        List<string> bookmarkPrograms = (List<string>)Session["BookmarkProgram"];
        if (bookmarkPrograms == null)
            bookmarkPrograms = new List<string>();
        
        if (bookmarkPrograms.Any(c => c.Equals(stringProgramID)))
        {
            FormMessage.Text = "You bookmarked this program already";
        }
        else
        {
            bookmarkPrograms.Add(stringProgramID);
        }
        Session["BookmarkProgram"] = bookmarkPrograms;
        
    }
