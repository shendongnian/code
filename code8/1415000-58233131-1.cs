    // pContent is my FlowLayoutPanel, it has FlowDirection set to TopDown
    // and WrapContent = true;
    pContent.SuspendLayout();
    // Populate the FlowLayoutPanel with controls
    pContent.ResumeLayout();
    // I want to show only HorizontalScrollbar
    if (pContent.VerticalScroll.Visible)
        {
            pContent.AutoScroll = false;
            pContent.VerticalScroll.Visible = false;
            pContent.Height -= SystemInformation.HorizontalScrollBarHeight;
            pContent.AutoScroll = true;
            pContent.Height += SystemInformation.HorizontalScrollBarHeight;    
        }
    
