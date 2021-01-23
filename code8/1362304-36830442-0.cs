    public static void Main(string[] args) {
        try 
        {
          ProcessStartInfo psi = new ProcessStartInfo();
          psi.FileName = "C:\\Windows\\System32\\cmd.exe"; // full path
          psi.CreateNoWindow = true; 
          psi.UseShellExecute = false;
          Process childProcess = Process.Start(psi); // child process
          // This code assumes the process you are starting will terminate itself. 
          // Given that is is started without a window so you cannot terminate it 
          // on the desktop, it must terminate itself or you can do it programmatically
          // from this application using the Kill method.
        }
        catch(Exception ex)
        {
            Console.WriteLine(e.Message);
        }
    }
