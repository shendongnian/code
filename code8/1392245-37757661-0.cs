      for (int i = 0; i < stringbytes.Length; i++)
      {
                var x = double.Parse(stringbytes[i]);
                Console.WriteLine(x);
                x = Math.Round((x * 100000) / date,0);
                byte finalbytes = Convert.ToByte(x);
                bytes.Add(finalbytes);
      }
