        foreach (string course in Courses)
        {
            if (MessageContents.Contains(course))
                Display_Course.Text = course;
        }
        if (MessageContents.Contains("Postgraduate"))
            Display_UGPG.Text = "Postgraduate";
        else if (MessageContents.Contains("Undergraduate"))
            Display_UGPG.Text = "Undergraduate";
        if(string.IsNullOrWhitespace(Display_Course.Text))
            Display_Course.Text = "N/A";
        if(string.IsNullOrWhitespace(Display_UGPG.Text ))
            Display_UGPG.Text  = "N/A";
