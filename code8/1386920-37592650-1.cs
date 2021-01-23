    ProgramA{
    string ip ="123.123.123";
    File.WriteAllText("c://MtDataFromA.txt","ip="+ip);
    }
    
    private void btnFinish_Click(object sender, EventArgs e)
                {
                    ipAddress = File.WriteAllText("c://MtDataFromA.txt");//some algorithem to find the ip from text file
    
        }
    
    public static void StoreAndBindCertificate(string pfxFileServerCert, string ipAddress, string ipPort){
    
    
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "YourFile.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "ipAddress"+" " +"ipPort";
    
            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
    catch
            {
                 // Log error.
            }
    }
