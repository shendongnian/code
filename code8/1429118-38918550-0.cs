    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    
    public class Maze
    {
        private const string InputFileName = "Labyrinth.in";
        private const string OutputFileName = "Labyrinth.out";
    
        public class Cell
        {
            public int Row { get; set; }
            public int Column { get; set; }
    
            public Cell(int row, int column)
            {
                this.Row = row;
                this.Column = column;
            }
        }
    
        private char[,] maze;
        private int size;
        private Cell startCell = null;
    
        public void ReadFromFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                // Read maze size and create maze
                this.size = int.Parse(reader.ReadLine());
                this.maze = new char[this.size, this.size];
    
                // Read the maze cells from the file
                for (int row = 0; row < this.size; row++)
                {
                    string line = reader.ReadLine();
                    for (int col = 0; col < this.size; col++)
                    {
                        this.maze[row, col] = line[col];
                        if (line[col] == '*')
                        {
                            this.startCell = new Cell(row, col);
                        }
                    }
                }
            }
        }
    
        public void FindAllPathsAndPrintThem()
        {
            if (this.startCell == null)
            {
                // Start cell is missing -> no path
                SaveResult(OutputFileName, "");
                return;
            }
    
            VisitCell(this.startCell.Row,
                this.startCell.Column, "");
        }
    
        private void VisitCell(int row, int column, string path)
        {
            if (row < 0 || column < 0 || row >= maze.GetLength(0) || column >= maze.GetLength(1))
            {
                return;
            }
            if (row < 0 || row > maze.GetLength(0) - 1 ||
                column < 0 || column > maze.GetLength(1) - 1)
            {
                SaveResult(OutputFileName, path);
                return;
            }
    
            if (this.maze[row, column] != '#')
            {
                // The cell is free --> visit it
                char x = this.maze[row, column];
                this.maze[row, column] = '#';
                VisitCell(row, column + 1, path + x);
                VisitCell(row, column - 1, path + x);
                VisitCell(row + 1, column, path + x);
                VisitCell(row - 1, column, path + x);
                this.maze[row, column] = x;
            }
        }
    
        public void SaveResult(string fileName, string result)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(result);
            }
        }
    
        static void Main()
        {
            Maze maze = new Maze();
            maze.ReadFromFile(InputFileName);
            maze.FindAllPathsAndPrintThem();
        }
    }
