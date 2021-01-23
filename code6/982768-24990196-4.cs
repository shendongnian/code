    private void DisplayMemory()
    {
        // Consumer of the NativeMethods class shown below
        long tm = System.GC.GetTotalMemory(true);
        NativeMethods oMemoryInfo = new NativeMethods();
        this.lblMemoryLoadNumber.Text = oMemoryInfo.MemoryLoad.ToString();
        this.lblIsMemoryTight.Text = oMemoryInfo.isMemoryTight().ToString();
        if (oMemoryInfo.isMemoryTight())
            this.lblIsMemoryTight.Text.Font.Bold = true;
        else
            this.lblIsMemoryTight.Text.Font.Bold = false;
    }
