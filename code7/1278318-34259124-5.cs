    public static class Solver
    {
        public static int Solve(string fileName, char shapeChar)
        {
            string[] lines = File.ReadAllLines(fileName);
            var rows = int.Parse(lines[0]);
            var cols = int.Parse(lines[1]);
            lines = lines.Skip(2).ToArray();
            UnionFindNode<char>[] nodes = new UnionFindNode<char>[rows * cols];
            for (int r = 0; r < rows; r++)
            {
                string line = lines[r];
                for (int c = 0; c < cols; c++)
                {
                    UnionFindNode<char> current = new UnionFindNode<char>(line[c]);
                    nodes[c*rows + r] = current;
                    if (c > 0)
                    {
                        Combine(current, nodes[(c - 1) * rows + r], current.Value);
                    }
                    if (r > 0)
                    {
                        Combine(current, nodes[c * rows + r - 1], current.Value);
                    }
                }
            }
            return nodes.Where(x => x.Value == shapeChar).Select(x => x.Find()).Distinct().Count();
        }
        private static void Combine(UnionFindNode<char> current, UnionFindNode<char> n, char shapeChar)
        {
            if (n.Value == shapeChar)
            {
                n.Union(current);
            }
        }
    }
