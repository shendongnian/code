    int procID = int.Parse(txtProcessID.Text);
    Process process = Process.GetProcessById(procID, ".");
    PROCESS_DPI_AWARENESS value;
    int res = GetProcessDpiAwareness(process.Handle, out value);
    if (res == S_OK)
        txtResult.Text = value.ToString();
    else
        txtResult.Text = "Error: " + res.ToString("X");
    process.Close();
