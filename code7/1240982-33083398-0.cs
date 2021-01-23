    public YourWindow 
    {
       int LastTokenNumberIssued;
       private void btnPrintToken_Click(object sender, EventArgs e)
       {
          int nextTokenNumberIssued;
          
          LastTokenNumberIssued = LastTokenNumberIssued++;
          nextTokenNumberTobeIssued = LastTokenNumberIssued;
       }
    }
