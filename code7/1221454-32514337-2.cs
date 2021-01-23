    private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        if (this.ObjectsEnumerator != null)
        {
            this.ObjectsEnumerator.Dispose();
            this.ObjectsEnumerator = null;
        }
    }
