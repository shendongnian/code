        var data = new ConcurrentStack<List<Bytes>>();
        var sw = new Stopwatch();
        sw.Start();
        Parallel.For(0, 5, () => new List<Bytes>(3*4*3*4*3*3*4*2*4*4*3*4),
          (a, loop, localList) => {
            var bytes = new Bytes();
            bytes.A = (byte) a;
            for (byte b = 0; b < 3; b++) {
              bytes.B = b;
              for (byte c = 0; c < 4; c++) {
                bytes.C = c; 
                for (byte d = 0; d < 3; d++) {
                  bytes.D = d; 
                  for (byte e = 0; e < 4; e++) {
                    bytes.E = e; 
                    for (byte f = 0; f < 3; f++) {
                      bytes.F = f; 
                      for (byte g = 0; g < 3; g++) {
                        bytes.G = g; 
                        for (byte h = 0; h < 4; h++) {
                          bytes.H = h; 
                          for (byte i = 0; i < 2; i++) {
                            bytes.I = i; 
                            for (byte j = 0; j < 4; j++) {
                              bytes.J = j; 
                              for (byte k = 0; k < 4; k++) {
                                bytes.K = k; 
                                for (byte l = 0; l < 3; l++) {
                                  bytes.L = l;
                                  for (byte m = 0; m < 4; m++) {
                                    bytes.M = m;
                                    localList.Add(bytes);
                                  }
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
 
                                    
            return localList;
          }, x => {
            data.Push(x);
        });
        var joinedData = _join(data);
