      var data = new ConcurrentStack<byte[]>();
      Parallel.For(0, 2, (a) => {
        Parallel.For(0, 3, (b) => {
          for (byte c = 0; c < 4; c++)
            for (byte d = 0; d < 3; d++)
              for (byte e = 0; e < 4; e++)
                for (byte f = 0; f < 3; f++)
                  for (byte g = 0; g < 3; g++)
                    for (byte h = 0; h < 4; h++)
                      for (byte i = 0; i < 2; i++)
                        for (byte j = 0; j < 4; j++)
                          for (byte k = 0; k < 4; k++)
                            for (byte l = 0; l < 3; l++)
                              for (byte m = 0; m < 4; m++)
                                data.Push(new[] { (byte)a, (byte)b, c, d, e, f, g, h, i, j, k, l, m });
        });
      });
