            if (Universities.Select(p => MessageContents.Contains(p)).Any())
            {
                Display_Uni.Text = Uni_Name;
            }
            else if (Courses.Select(p => MessageContents.Contains(p)).Any())
            {
                Display_Course.Text = course;
            }
            else if (MessageContents.Contains("Postgraduate"))
            {
                Display_UGPG.Text = "Postgraduate";
            }
            else if (MessageContents.Contains("Undergraduate"))
            {
                Display_UGPG.Text = "Undergraduate";
            }
            else
            {
                Display_UGPG.Text = "N/A";
            }
