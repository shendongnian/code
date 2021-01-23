     public string hex="";
     public void filesHex(string path,int bytesToRead,string offsetLong)
     {
            byte[] byVal;
      
          using (Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
          {
              BinaryReader brFile = new BinaryReader(fileStream);
              offsetLong = offsetLong.Replace("x", string.Empty);
              long result = 0;
              long.TryParse(offsetLong, System.Globalization.NumberStyles.HexNumber, null, out result);
              fileStream.Position = result;
              byte[] offsetByte = brFile.ReadBytes(0);
              string offsetString = HexStr(offsetByte);
              //long offset = System.Convert.ToInt64(offsetString, 16);
              byVal = brFile.ReadBytes(bytesToRead);
          }
          hex = HexStr(byVal).Substring(2);
          
      }
