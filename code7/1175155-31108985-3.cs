        private class FolderMaze
        {
            private const string SubDirectoryName = "Maze_";
            private readonly string baseDirectory;
            private readonly int depth;
            private readonly int nFoldersPerIteration;
            public FolderMaze(string baseDirectory, int depth, int nFoldersPerIteration)
            {
                this.baseDirectory = baseDirectory;
                this.depth = depth;
                this.nFoldersPerIteration = nFoldersPerIteration;
            }
            public void Magic()
            {
                this.Magic(0, this.baseDirectory);
            }
            private void Magic(int iteration, string iterationPath)
            {
                // exit condition
                if (iteration >= this.depth)
                {
                    return;
                }
                // Iteration
                for (int i = 0; i < this.nFoldersPerIteration; i++)
                {
                    var currentPath = Path.Combine(iterationPath, SubDirectoryName + i);
                    Directory.CreateDirectory(currentPath);
 
                    // recursive call to Magic(int string)
                    this.Magic(++iteration, currentPath);
                }
            }
        }
