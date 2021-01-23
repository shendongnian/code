    System.Web.UI.DataVisualization.Charting.Chart Chart1 = new System.Web.UI.DataVisualization.Charting.Chart();
    Chart1.Width = 412;
    Chart1.Height = 296;
    Chart1.RenderType = RenderType.ImageTag;
    //....
    // Render chart control
    Chart1.Page = this;
    HtmlTextWriter writer = new HtmlTextWriter(Page.Response.Output);
    Chart1.RenderControl(writer);
