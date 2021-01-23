    private void button1_Click(object sender, EventArgs e)
    {
        using (Py.GIL())
        {
            // Redirect stdout to text box
            dynamic sys = PythonEngine.ImportModule("sys");
            string codeToRedirectOutput =
                "import sys\n" +
                "from io import StringIO\n" +
                "sys.stdout = mystdout = StringIO()\n" +
                "sys.stdout.flush()\n" +
                "sys.stderr = mystderr = StringIO()\n" +
                "sys.stderr.flush()\n";
            PythonEngine.RunString(codeToRedirectOutput);            
            
            // Run Python code
            string pyCode = "print(1 + 2)";
            PyObject result = PythonEngine.RunString(pyCode); // null in case of error
            if (result != null)
            {
                string pyStdout = sys.stdout.getvalue(); // Get stdout
                pyStdout = pyStdout.Replace("\n", "\r\n"); // To support newline for textbox
                textBox1.Text = pyStdout;             
            }
            else
            {
                 PythonEngine.PrintError(); // Make Python engine print errors
                 string pyStderr = sys.stderr.getvalue(); // Get stderr
                 pyStderr = pyStderr.Replace("\n", "\r\n"); // To support newline for textbox
                 textBox1.Text = pyStderr;
            }     
        }
    }
