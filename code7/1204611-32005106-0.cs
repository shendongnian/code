    public sealed class WaitForReady<T> : IDisposable
    {
        public readonly ManualResetEvent mre = new ManualResetEvent(false);
        public T Value
        {
            get
            {
                mre.WaitOne();
                return this.value;
            }
            set
            {
                this.value = value;
                mre.Set();
            }
        }
        private T value;
        #region IDisposable Members
        public void Dispose()
        {
            mre.Dispose();
        }
        #endregion
    }
    public class Field
    {
        public Field[] Neighbours;
        public Field(WaitForReady<Field> me, WaitForReady<Field>[] neighbours)
        {
            me.Value = this;
            Neighbours = new Field[neighbours.Length];
            for (int i = 0; i < neighbours.Length; i++)
            {
                Neighbours[i] = neighbours[i] != null ? neighbours[i].Value : null;
            }
        }
    }
    public static void Main(string[] args)
    {
        int boardsize = 8;
        Field[,] board = new Field[boardsize, boardsize];
        
        WaitForReady<Field>[,] boardTemp = null;
        try
        {
            boardTemp = new WaitForReady<Field>[boardsize, boardsize];
            var threads = new Thread[boardsize * boardsize];
            for (int i = 0; i < boardsize; i++)
            {
                for (int j = 0; j < boardsize; j++)
                {
                    boardTemp[i, j] = new WaitForReady<Field>();
                }
            }
            int k = 0;
            for (int i = 0; i < boardsize; i++)
            {
                for (int j = 0; j < boardsize; j++)
                {
                    var neighbours = new WaitForReady<Field>[8];
                    neighbours[0] = i > 0 && j > 0 ? boardTemp[i - 1, j - 1] : null;
                    neighbours[1] = i > 0 ? boardTemp[i - 1, j] : null;
                    neighbours[2] = i > 0 && j + 1 < boardsize ? boardTemp[i - 1, j + 1] : null;
                    neighbours[3] = j > 0 ? boardTemp[i, j - 1] : null;
                    neighbours[4] = j + 1 < boardsize ? boardTemp[i, j + 1] : null;
                    neighbours[5] = i + 1 < boardsize && j > 0 ? boardTemp[i + 1, j - 1] : null;
                    neighbours[6] = i + 1 < boardsize ? boardTemp[i + 1, j] : null;
                    neighbours[7] = i + 1 < boardsize && j + 1 < boardsize ? boardTemp[i + 1, j + 1] : null;
                    int i1 = i, j1 = j;
                    threads[k] = new Thread(() => board[i1, j1] = new Field(boardTemp[i1, j1], neighbours));
                    threads[k].Start();
                    k++;
                }
            }
            // Wait for all the threads
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
        }
        finally
        {
            // Dispose the WaitForReady
            if (boardTemp != null)
            {
                for (int i = 0; i < boardsize; i++)
                {
                    for (int j = 0; j < boardsize; j++)
                    {
                        if (boardTemp[i, j] != null)
                        {
                            boardTemp[i, j].Dispose();
                        }
                    }
                }
            }
        }
    }
