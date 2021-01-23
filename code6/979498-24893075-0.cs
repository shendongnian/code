    {
      string file = "TrashV1.exe"; // Input EXE
      string fileout = "TrashV2.exe";
      File.Delete(fileout);
      byte[] barr = File.ReadAllBytes(file);
      int offset = 0x73e; // NOTE! This is one LESS than the offset that MCaffee reported!
      
      string replace = "AK";
      var enc = new System.Text.UnicodeEncoding();
      byte[] unicode = enc.GetBytes(replace);
      for (int i = 0; i < unicode.Length; i++)
      {
        barr[offset + i] = unicode[i];
      }
      File.WriteAllBytes(fileout, barr);
    }
