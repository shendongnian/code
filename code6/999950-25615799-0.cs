                int size = rows * columns;
                byte[] pData = new byte[size]; 
                int i = 0;
                for (int row = 0; row < rows; ++row)
                {
                    for (int column = 0; column < columns; column++)
                    {
                        pData[i++] = image.GetPixel(column, row).R;
                    }
                }
