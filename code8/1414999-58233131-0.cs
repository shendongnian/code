    // pContent is my FlowLayoutPanel
    pContent.SuspendLayout();
    // Populate the FlowLayoutPanel with controls
    pContent.ResumeLayout();
    if (pContent.VerticalScroll.Visible)
        {
            pContent.AutoScroll = false;
            pContent.VerticalScroll.Visible = false;
            pContent.Height -= SystemInformation.HorizontalScrollBarHeight;
            pContent.AutoScroll = true;
            pContent.Height += SystemInformation.HorizontalScrollBarHeight;    
        }
