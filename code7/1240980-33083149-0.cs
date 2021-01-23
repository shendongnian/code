    int LastTokenNumberIssued = 0; //give it a default value here.
    int nextTokenNumberTobeIssued = 0; //give it a default value here.
    
    private void btnPrintToken_Click(object sender, EventArgs e)
    {
        ....
        nextTokenNumberTobeIssued = LastTokenNumberIssued + 1;
        LastTokenNumberIssued = nextTokenNumberTobeIssued;
        ...
    }
