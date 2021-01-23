    ...
    using System.Diagnostics;
    ...
    private void button4_Click(object sender, EventArgs e)
    {
        string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string snat = Environment.GetEnvironmentVariable("windir") + @"\sysnative\sfc.exe";
        Process a = new Process();
          a.StartInfo.FileName = snat;
          a.StartInfo.Arguments = "/SCANNOW";
          a.StartInfo.UseShellExecute = false;
          a.StartInfo.RedirectStandardOutput = true;
          a.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
          a.StartInfo.CreateNoWindow = true;
        a.Start();
        string output = a.StandardOutput.ReadToEnd();
        a.WaitForExit();
        MessageBox.Show("DONE!");
    }
    catch
    {
    MessageBox.Show("error!");
    }
