    private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.WindowSelectionChange += OnWindowSelectionChanged;
        }
    void OnWindowSelectionChanged(PowerPoint.Selection Sel)
        {
            if (Sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                 PowerPoint.ShapeRange shapeRange = Sel.ShapeRange;
                 //Do some work
            }
        }
    private void ThisAddIn_ShutDown(object sender, System.EventArgs e)
        {
            this.Application.WindowSelectionChange -= OnWindowSelectionChanged;
        }
