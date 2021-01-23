    public class Star 
        {
            public int _X = 0;
            public int _Y = 0;
            public double _Speed = 0.0f;
            public int _Direction;
            public Star(int x, int y, double speed)
            {
                _X = x;
                _Y = y;
                _Speed = speed;
            }
            public Star(Random rndGen, Window wdw)
            {
                _X = rndGen.Next(-(int)Math.Floor((wdw.Width / 8)), (int)Math.Floor((wdw.Width / 8)));
                _Y = rndGen.Next(-(int)Math.Floor((wdw.Height / 8)), (int)Math.Floor((wdw.Height / 8)));
                _Speed = rndGen.Next(1, 100) / 100;
                _Direction = rndGen.Next(0, 4);
            }
        }
