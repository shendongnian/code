    void main()
    {
        var psi = new ProcessStartInfo("fileName.exe", "<arguments>");
        psi.UseShellExecute = false;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;
        var p = Process.Start(psi);
        p.OutputDataReceived += p_OutputDataReceived;
        p.ErrorDataReceived += p_ErrorDataReceived;
        p.WaitForExit();
    }
    static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        //react on the received error data in e.Data.
    }
    static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        //react on the received output data in e.Data.
    }
