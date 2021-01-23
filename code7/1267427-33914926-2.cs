    using System.Windows.Forms; // to have "Clipboard" class
    using System.IO;            // to have "File" class
       ...
    var lines = File
      .ReadLines(@"C:\Users\st4r8_000\Desktop\office work\checks documents\interface check commands.txt");
    
    StringBuilder clipBuffer = new StringBuilder();
    
    foreach(String line in lines) {
      Console.WriteLine(line);
    
      if (clipBuffer.Length > 0)
        clipBuffer.Append('\n');
    
      clipBuffer.Append(line);
      
      // Incremental addition; 
      // Clipboard.SetText(line); 
      // if new line should superecede the old one
      Clipboard.SetText(clipBuffer.ToString());
    
      Console.ReadLine();
    }
