    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Cell cells = new Cell(11,13);
                cells.SetCell(0, 0, 0, -1, -1, -1, -1);
                cells.SetCell(0, 0, 1, -1, -1, -1, -1);
                cells.SetCell(1, 0, 2, 1, 2, -1, -1);
                cells.SetCell(0, 0, 3, -1, -1, -1, -1);
                cells.SetCell(0, 0, 4, -1, -1, -1, -1);
                cells.SetCell(0, 0, 5, -1, -1, -1, -1);
                cells.SetCell(0, 0, 6, -1, -1, -1, -1);
                cells.SetCell(0, 0, 7, -1, -1, -1, -1);
                cells.SetCell(0, 0, 8, -1, -1, -1, -1);
                cells.SetCell(0, 0, 9, -1, -1, -1, -1);
                cells.SetCell(0, 0, 10, -1, -1, -1, -1);
                cells.SetCell(0, 0, 11, -1, -1, -1, -1);
                cells.SetCell(0, 0, 12, -1, -1, -1, -1);
                cells.SetCell(0, 1, 0, -1, -1, -1, -1);
                cells.SetCell(0, 1, 1, -1, -1, -1, -1);
                cells.SetCell(1, 1, 2,  1,  3,  0,  2);
                cells.SetCell(1, 1, 3,  2,  3,  1,  2);
                cells.SetCell(0, 1, 4, -1, -1, -1, -1);
                cells.SetCell(0, 1, 5, -1, -1, -1, -1);
                cells.SetCell(0, 1, 6, -1, -1, -1, -1);
                cells.SetCell(0, 1, 7, -1, -1, -1, -1);
                cells.SetCell(0, 1, 8, -1, -1, -1, -1);
                cells.SetCell(0, 1, 9, -1, -1, -1, -1);
                cells.SetCell(0, 1, 10, -1, -1, -1, -1);
                cells.SetCell(0, 1, 11, -1, -1, -1, -1);
                cells.SetCell(0, 1, 12, -1, -1, -1, -1);
            }
        }
        public class Cell
        {
            static List<List<Cell>> map = new List<List<Cell>>();
            public int value { get; set; }
            public int row { get; set; }
            public int col { get; set; }
            public Cell next { get; set; }
            public Cell previous { get; set; }
            public Cell() { }
            public Cell(int nRows, int nCol)
            {
                for (int row = 0; row < nRows; row++)
                {
                    List<Cell> newRow = new List<Cell>();
                    map.Add(newRow);
                    for (int col = 0; col < nCol; col++)
                    {
                        Cell newCell = new Cell();
                        newCell.next = null;
                        newCell.previous = null;
                        newRow.Add(newCell);
                    }
                }
            }
            public void SetCell(int xValue, int xRow, int xCol, int nextRow, int nextCol, int previousRow, int previousCol)
            {
                value = xValue;
                row = xRow;
                col = xCol;
                if (value == 1)
                {
                    if(nextRow != -1)
                       map[row][col].next = map[nextRow][nextCol];
                    if(previousRow != -1)
                       map[row][col].previous = map[previousRow][previousCol];
                }
            }
            
        }
        
    }
    ​
