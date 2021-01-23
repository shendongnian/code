    private void btnFolder_Click(object sender, EventArgs e)
    {
      DialogResult result = folderBrowserDialog1.ShowDialog();
      if (result == DialogResult.OK)
      {
        _path = folderBrowserDialog1.SelectedPath;
        txtInput.Text = _path;
        // assuming you want to include nested folders
        var files = Directory.GetFiles(_path, "*.*", SearchOption.TopDirectoryOnly)
                              .OrderBy(p => p).ToList();
        MD5 totalMD5 = MD5.Create();
        int bytesToReadAtOnce = 2048; // NOTE: This can be changed to bigger or smaller.
        foreach (string singleFile in files)
        {
          MD5 singleMD5 = MD5.Create();
            
          // hash contents
          // NOTE: This is nice for small files, but a memory eater for big files
          //byte[] contentBytes = File.ReadAllBytes(singleFile);
          //singleMD5.TransformFinalBlock(contentBytes, 0, contentBytes.Length);
          using (FileStream inputFile = File.OpenRead(singleFile))
          {
            byte[] content = new byte[bytesToReadAtOnce];
            int bytesRead = 0;
            // Read the file only in chunks, allowing minimal memory usage.
            while ((bytesRead = inputFile.Read(content, 0, bytesToReadAtOnce)) > 0)
            {
              totalMD5.TransformBlock(content, 0, bytesRead, content, 0);
              singleMD5.TransformBlock(content, 0, bytesRead, content, 0);
            }
            // !!! NOTE !!! Including the path to the file in the hash will result in a different MD5 if the file is going to be downloaded, copied or renamed
            // Add the file's Path to the end of the hash and finalize the hash
            byte[] singleFilePathBytes = Encoding.UTF8.GetBytes(singleFile);
            singleMD5.TransformFinalBlock(singleFilePathBytes, 0, singleFilePathBytes.Length);
            // Output per file
            lstBox.Items.Add(string.Format("File: {0}", singleFile));
            lstBox.Items.Add(string.Format("MD5 : {0}", BitConverter.ToString(singleMD5.Hash).Replace("-", "").ToUpper()));
          }
        }
        // Add the original selected Path to finalize the hash
        byte[] pathBytes = Encoding.UTF8.GetBytes(_path);
        totalMD5.TransformFinalBlock(pathBytes, 0, pathBytes.Length);
        // Output for total
        lstBox.Items.Insert(0, Environment.NewLine);
        lstBox.Items.Insert(0, string.Format("Total MD5 : {0}", BitConverter.ToString(totalMD5.Hash).Replace("-", "").ToUpper()));
        lstBox.Items.Insert(0, string.Format("Root Path : {0}", _path));
      }
      else
      {
        return;
      }
    }
