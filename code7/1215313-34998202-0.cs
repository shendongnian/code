    private void nxtBtn_Click(object sender, EventArgs e)
    {
        if (PrevIndex < PgCount)
            ++PrevIndex;
        if (PrevIndex == PgCount - 1)
            nxtBtn.Enabled = false;
        prvBtn.Enabled = true;
        ppd.PrintPreviewControl.InvalidatePreview();
        fName = GetFName();
        if (PublicVariables.PrintData == 2)
            Show_Page();
        else
        {
            pd.DocumentName = fName;
            ppd.Document = pd;
            ppc.Document = pd;
            ppc.InvalidatePreview();
        }
        label2.Text = (PrevIndex + 1).ToString();
    }
