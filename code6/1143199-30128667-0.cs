      const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789+-*_!$£^=<>§°ÖÄÜöäü.;:,?{}[]";
      var byteAlphabet = alphabet.Select(ch => (byte)ch).ToArray();
      var alphabetLength = alphabet.Length;
      var newLine = new[] { (byte)'\r', (byte)'\n' };
      const int size = 4;
      var number = new byte[size];
      var password = Enumerable.Range(0, size).Select(i => byteAlphabet[0]).Concat(newLine).ToArray();
      var watcher = new System.Diagnostics.Stopwatch();
      watcher.Start();
      var isRunning = true;
      for (var counter = 0; isRunning; counter++)
      {
        Console.Write("{0}: ", counter);
        Console.Write(password.Select(b => (char)b).ToArray());
        using (var file = System.IO.File.Create(string.Format(@"list.{0:D5}.txt", counter), 2 << 16))
        {
          for (var i = 0; i < 2000000; ++i)
          {
            file.Write(password, 0, password.Length);
            var j = size - 1;
            for (; j >= 0; j--)
            {
              if (number[j] < alphabetLength - 1)
              {
                password[j] = byteAlphabet[++number[j]];
                break;
              }
              else
              {
                number[j] = 0;
                password[j] = byteAlphabet[0];
              }
            }
            if (j < 0)
            {
              isRunning = false;
              break;
            }
          }
        }
      }
      watcher.Stop();
      Console.WriteLine(watcher.Elapsed);
    }
