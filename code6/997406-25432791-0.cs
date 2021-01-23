    var startCell = ws.Cells[1, 1];
            int row = Y, col = X;
            var endCell = ws.Cells[row, col];
            // access range by Property and cells indicating start and end 
            var writeRange = ws.Range[startCell, endCell];
            var _pixels = new double[Y, X];
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                  
                    _pixels[y, x] = (double)Pixels[y, x];
                }
            }
          
            writeRange.Value = _pixels;
