     private void getBytes()
        {
            int numBytes = bitsPerSample / 8;
            int numTiles = tif.NumberOfTiles();
            int stride = numBytes * height;
            int bufferSize = tileWidth * tileHeight * numBytes * numTiles;
            int bytesSavedPerTile = tileWidth * tileHeight * numBytes; //this is the real size of the decompressed bytes
            byte[] bufferTiff = new byte[bufferSize];
            FieldValue[] value = tif.GetField(TiffTag.TILEWIDTH);
            int tilewidth = value[0].ToInt();
            value = tif.GetField(TiffTag.TILELENGTH);
            int tileHeigth = value[0].ToInt();
            int matrixSide = (int)Math.Sqrt(numTiles); // this works for a square image (for example a tiles organized tiff image)
            int bytesWidth = matrixSide * tilewidth;
            int bytesHeigth = matrixSide * tileHeigth;
            int offset = 0;
            for (int j = 0; j < numTiles; j++)
            {
                offset += tif.ReadEncodedTile(j, bufferTiff, offset, bytesSavedPerTile); //Here was the mistake. Now it works!
            }
            double[,] aux = new double[bytesHeigth, bytesWidth]; //Double for a 64 bps tiff image. This matrix will save the alldata, including the transparency (the "blank zone" I was talking before)
            terrainElevation = new double[height, width]; // Double for a 64 bps tiff image. This matrix will save only the elevation values, without transparency
            int ptr = 0;
            int m = 0;
            int n = -1;
            int contNumTile = 1;
            int contBytesPerTile = 0;
            int i = 0;
            int tileHeigthReference = tileHeigth;
            int tileWidthReference = tileWidth;
            int row = 1;
            int col = 1;
            byte[] bytesHeigthMeters = new byte[numBytes]; // Buffer to save each one elevation value to parse
            while (i < bufferTiff.Length && contNumTile < numTiles + 1)
            {
                for (contBytesPerTile = 0; contBytesPerTile < bytesSavedPerTile; contBytesPerTile++)
                {
                    bytesHeigthMeters[ptr] = bufferTiff[i];
                    ptr++;
                    if (ptr % numBytes == 0 && ptr != 0)
                    {
                        ptr = 0;
                        n++;
                        if (n == tileHeigthReference)
                        {
                            n = tileHeigthReference - tileHeigth;
                            m++;
                            if (m == tileWidthReference)
                            {
                                m = tileWidthReference - tileWidth;
                            }
                        }
                        double heigthMeters = BitConverter.ToDouble(bytesHeigthMeters, 0);
                        if (n < bytesWidth)
                        {
                            aux[m, n] = heigthMeters;
                        }
                        else
                        {
                            n = -1;
                        }
                    }
                    i++;
                }
                if (i % tilewidth == 0)
                {
                    col++;
                    if (col == matrixSide + 1)
                    {
                        col = 1;
                    }
                }
                if (contNumTile % matrixSide == 0)
                {
                    row++;
                    n = -1;
                    if (row == matrixSide + 1)
                    {
                        row = 1;
                       
                    }
                }
                contNumTile++;
                tileHeigthReference = tileHeight * (col);
                tileWidthReference = tileWidth * (row);
                m = tileWidth * (row - 1);
            }
            
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    terrainElevation[x, y] = aux[x, y]; // Final result. Each position of matrix has saved each pixel terrain elevation of the map
                }
            }
        }
