    private void alignment()
         {
            string strSeq1;
            string strSeq2;
            string strTemp1;
            string strTemp2;
            scoreMatrix = new int[Log.Length, Log.Length];
            // Lists That Holds Alignments
            List<char> SeqAlign1 = new List<char>();
            List<char> SeqAlign2 = new List<char>();
	       for (int i = 0; i<Log.Length; i++ )
            {
                for (int j=i+1 ; j<Log.Length; j++)
                {
                    strSeq1 = "--" + logFile.Sequence(i);
                    strSeq2 = "--" + logFile.Sequence(j);
                    //prepare Matrix for Computing optimal alignment
                    Cell[,] Matrix = DynamicProgramming.Intialization_Step(strSeq1, strSeq2, intSim, intNonsim, intGap);
                    // Trace back matrix from end cell that contains max score 
                    DynamicProgramming.Traceback_Step(Matrix, strSeq1, strSeq2, SeqAlign1, SeqAlign2);
                    this.scoreMatrix[i, j] = DynamicProgramming.intMaxScore;
                    strTemp1 = Reverse(string.Join("", SeqAlign1));
                    strTemp2 = Reverse(string.Join("", SeqAlign2));
                }
            }
	}
    class DynamicProgramming
    {
        public  static Cell[,] Intialization_Step(string Seq1, string Seq2,int Sim,int NonSimilar,int Gap)
        {
            int M = Seq1.Length / 2 ;//Length+1//-AAA    //Changed: /2
            int N = Seq2.Length / 2 ;//Length+1//-AAA
            Cell[,] Matrix = new Cell[N, M];
            //Intialize the first Row With Gap Penality Equal To Zero 
            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                Matrix[0, i] = new Cell(0, i, 0);
            }
            //Intialize the first Column With Gap Penality Equal To Zero 
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                Matrix[i, 0] = new Cell(i, 0, 0);
            }
            // Fill Matrix with each cell has a value result from method Get_Max
            for (int j = 1; j < Matrix.GetLength(0); j++)
            {
                for (int i = 1; i < Matrix.GetLength(1); i++)
                {
                    Matrix[j, i] = Get_Max(i, j, Seq1, Seq2, Matrix,Sim,NonSimilar,Gap);
                }
            }
            return Matrix;
        }
        public  static Cell Get_Max(int i, int j, string Seq1, string Seq2, Cell[,] Matrix,int Similar,int NonSimilar,int GapPenality)
        {
            Cell Temp = new Cell();
            int intDiagonal_score;
            int intUp_Score;
            int intLeft_Score;
            int Gap = GapPenality;
            //string temp1, temp2;
            //temp1 = Seq1[i*2].ToString() + Seq1[i*2 + 1]; temp2 = Seq2[j*2] + Seq2[j*2 + 1].ToString();
            if ((Seq1[i * 2] + Seq1[i * 2 + 1]) == (Seq2[j * 2] + Seq2[j * 2 + 1]))  //Changed: +
            {
                intDiagonal_score = Matrix[j - 1, i - 1].CellScore + Similar;
            }
            else
            {
                intDiagonal_score = Matrix[j - 1, i - 1].CellScore + NonSimilar;
            }
            //Calculate gap score
            intUp_Score = Matrix[j - 1, i].CellScore + GapPenality;
            intLeft_Score = Matrix[j, i - 1].CellScore + GapPenality;
            if (intDiagonal_score<=0 && intUp_Score<=0 && intLeft_Score <= 0)
            {
                return Temp = new Cell(j, i, 0);     
            }
            if (intDiagonal_score >= intUp_Score)
            {
                if (intDiagonal_score>= intLeft_Score)
                {
                    Temp = new Cell(j, i, intDiagonal_score, Matrix[j - 1, i - 1], Cell.PrevcellType.Diagonal);
                }
                else
                {
                    Temp = new Cell(j, i, intDiagonal_score, Matrix[j , i - 1], Cell.PrevcellType.Left);
                }
            }
            else
            {
                if (intUp_Score >= intLeft_Score)
                {
                    Temp = new Cell(j, i, intDiagonal_score, Matrix[j - 1, i], Cell.PrevcellType.Above);
                }
                else
                {
                    Temp = new Cell(j, i, intDiagonal_score, Matrix[j , i - 1], Cell.PrevcellType.Left);
                }
            }
            if (MaxScore.CellScore <= Temp.CellScore)
            {
                MaxScore = Temp;
            }
            return Temp;
        }
        public static void Traceback_Step(Cell[,] Matrix, string Sq1, string Sq2, List<char> Seq1, List<char> Seq2)
        {
            intMaxScore = MaxScore.CellScore;
            while (MaxScore.CellPointer != null)
            {
                if (MaxScore.Type == Cell.PrevcellType.Diagonal)
                {
                    Seq1.Add(Sq1[MaxScore.CellColumn * 2 + 1]);  //Changed: All of the following lines with *2 and +1
                    Seq1.Add(Sq1[MaxScore.CellColumn * 2]);
                    Seq2.Add(Sq2[MaxScore.CellRow * 2 + 1]);
                    Seq2.Add(Sq2[MaxScore.CellRow * 2]);
                }
                if (MaxScore.Type == Cell.PrevcellType.Left)
                {
                    Seq1.Add(Sq1[MaxScore.CellColumn * 2 + 1]);
                    Seq1.Add(Sq1[MaxScore.CellColumn * 2]);
                    Seq2.Add('-');
                }
                if (MaxScore.Type == Cell.PrevcellType.Above)
                {
                    Seq1.Add('-');
                    Seq2.Add(Sq2[MaxScore.CellRow * 2 + 1]);
                    Seq2.Add(Sq2[MaxScore.CellRow * 2]);
                }
                MaxScore = MaxScore.CellPointer;
            }          
        }
    }
  
