    [ToolboxData("<{0}:MyReportViewerControl runat=server></{0}:MyReportViewerControl>")]
    public class MyReportViewerControl : CompositeControl, IPostBackEventHandler, IPostBackDataHandler
    {
         //additional code
         protected override void CreateChildControls()
         {
             //Here add you customized reportviewer
             var rv = new CustomReportViewer();
             rv.AsyncRendering = false;
         }
         //additional code
    }
