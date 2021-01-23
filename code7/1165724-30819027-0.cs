    private void encryptF_Click(object sender, EventArgs e)
    {
        pwdE = keyE.Text;
        if (inputE != null && outputE != null && pwdE != null)
        {
            string outputFile = Path.Combine(outputE, Path.GetFileName(inputE));
            proceedEDfe(inputE, outputFile, pwdE);
        }
    }
