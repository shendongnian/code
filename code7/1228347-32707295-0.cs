     Regex pattern = new Regex(@"\[[\w :]+\]\s<SYSTEMWIDE_MESSAGE>:");
     long lastPosition = 0;
     private void OnChanged(object source, FileSystemEventArgs e)
     {
       string line;
       Stream stream = File.Open(e.FullPath, FileMode.Open, FileAccess.Read,     FileShare.ReadWrite);
       stream.Seek(lastPosition, SeekOrigin.Begin);
       StreamReader streamReader = new StreamReader(stream);
       while ((line = streamReader.ReadLine()) != null)
       {
          if (pattern.Match(line).Success)
          {
            tbOutput.AppendText(line + Environment.NewLine);
          }
       }
       lastPosition = stream.Position;  // may need to subtract 1!!!
       streamReader.Close();
       stream.Close();
    }
