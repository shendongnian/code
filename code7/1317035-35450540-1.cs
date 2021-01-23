    string ToHexString(float f) {
      var bytes = BitConverter.GetBytes(f);
      var i = BitConverter.ToInt32(bytes, 0);
      return "0x" + i.ToString("X8");
    }
    
    float FromHexString(string s) {
      var i = Convert.ToInt32(s, 16);
      var bytes = BitConverter.GetBytes(i);
      return BitConverter.ToSingle(bytes, 0);
    }
