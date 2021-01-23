    private void btnPrintPreview_Click(object sender, EventArgs e)
    {
        // Check whether the GridControl can be previewed.
        if (!gridControl1.IsPrintingAvailable)
        {
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
            return;
        }
       
    
        // Open the Preview window.
        gridControl1.ShowPrintPreview();
    }       
    
    private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
    {
        PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;            
        pb.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None);
        pb.SetCommandVisibility(PrintingSystemCommand.SendTxt, CommandVisibility.None);
        pb.SetCommandVisibility(PrintingSystemCommand.SendRtf, CommandVisibility.None);
        pb.SetCommandVisibility(PrintingSystemCommand.SendXls, CommandVisibility.None);
        pb.SetCommandVisibility(PrintingSystemCommand.SendMht, CommandVisibility.None);
        pb.SetCommandVisibility(PrintingSystemCommand.SendXlsx, CommandVisibility.None);
        pb.SetCommandVisibility(PrintingSystemCommand.SendCsv, CommandVisibility.None);
        pb.SetCommandVisibility(PrintingSystemCommand.SendGraphic, CommandVisibility.None);
    }
