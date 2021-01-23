     private void storyboard_Completed(object sender, EventArgs e)
        {
            string StoryBoardName = ((ClockGroup)sender).Timeline.Name;
            if (StoryBoardName == "storyboard1") { storyboard1.Stop(); storyboard1.Remove(); }
        }
