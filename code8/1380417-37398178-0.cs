    PicPaste btn = null;
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {                        
        btn = new PicPaste(this.Application);
    }
