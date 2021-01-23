    namespace WpfApplication1
    {
        public class MyViewModel
        {
            public char[][] MyArray { get; set; }
            public MyViewModel()
            {
                MyArray = new char[30][];
                for (int row = 0; row < 30; row++)
                {
                    MyArray[row] = new char[80];
                    for (int col = 0; col < 80; col++)
                    {
                        MyArray[row][col] = 'O';
                    }
                }
            }
        }
    }
