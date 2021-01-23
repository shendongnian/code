    // pContent has FlowDirection set to LeftRight and WrapContent = true;
    pContent.SuspendLayout();
    // Populate the FlowLayoutPanel with controls
    pContent.ResumeLayout();
    // I want to show only VerticalScrollbar
    if (pContent.HorizontalScroll.Visible)
        {
            pContent.AutoScroll = false;
            pContent.HorizontalScroll.Visible = false;
            pContent.Width -= SystemInformation.VerticalScrollBarWidth;
            pContent.AutoScroll = true;
            pContent.Width += SystemInformation.VerticalScrollBarWidth;    
        }
