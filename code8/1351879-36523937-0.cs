        public void TryThis()
        {
            for (int x = 0; x < matrix.GetLength(1); x++)
            {
                for (y = 0; y < matrix.GetLength(0); y++)
                {
                    iValue = iValue + matrix[y, x]; 
                }
                textBox1.Text =textBox1.Text+ ("Colum " + x + " Sum=" + iValue);
                iValue = 0;
            }
        }
