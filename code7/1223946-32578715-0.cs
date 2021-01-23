    using Microsoft.Office.Core;
    using Microsoft.Office.Interop.PowerPoint;
    
    private AxOfficeViewer.AxOfficeViewer axOfficeViewer1;
    private Microsoft.Office.Interop.PowerPoint.Presentation _presentation;
    
    public void OpenDocument(string fileName)
    {
        axOfficeViewer1.Visible = false;
    
        axOfficeViewer1.Open(fileName);
        axOfficeViewer1.Visible = true;
        axOfficeViewer1.SlideShowPlay(false, false, false, false);
    
        _presentation =
            axOfficeViewer1.ActiveDocument as Presentation;
    }
