    private void btnTwoByHalf_Click(ucPrinterSetup prn)
    {
        twoByHalf.PropName = "TwoByHalfPrn";
        twoByHalf.SetPrinter(twoByHalf.PropName);
        prn.lblTwoByHalf.Text = twoByHalf.Printer;
    }
