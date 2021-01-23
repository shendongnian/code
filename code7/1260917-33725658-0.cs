       public class MyGrid {
            public int Width { get; protected set; }
            public int Height { get; protected set; }
            
            public MyCell[,] MyCells { get; protected set; }
    
            public List<MyPath> MyPathList;
    
            public MyGrid(int h, int w) {
                this.Width = w;
                this.Height = h;
    
                this.MyCells = new MyCell[this.Width, this.Height];
                for (int x = 0; x < Width; x++) {
                    for (int y = 0; y < Width; y++) {
                        this.MyCells[x, y] = new MyCell(this, x, y);
                    }
                }
    
                this.MyPathList = new List<MyPath>();
            }
    
            public int FindPaths() {
                this.MyPathList.Clear();
    
                var p = new MyPath(this);
                this.MyPathList.Add(p);
    
                var c = new MyCell(this,0,0);
                p.AddCellRecursive(c); 
    
                return MyPathList.Count;
            }
    
        }
        public class MyCell {
            public MyGrid myGrid { get; protected set; }
            public int X { get; protected set; }
            public int Y { get; protected set; }
            public MyCell(MyGrid gr, int x, int y) {
                this.myGrid = gr;
                this.X = x;
                this.Y = y;
            }
            public MyCell RightNeighbour {
                get {
                    if (this.X == this.myGrid.Width-1)
                        return null;
                    else
                        return this.myGrid.MyCells[this.X+1, this.Y];
                }
            }
            public MyCell BelowNeighbour {
                get {
                    if (this.Y == this.myGrid.Height-1)
                        return null;
                    else
                        return this.myGrid.MyCells[this.X, this.Y+1];
                }
            }
            public override string ToString() {
                return string.Format("{0}|{1}", this.X, this.Y);
            }
        }
        public class MyPath{
            public MyGrid myGrid { get; protected set; }
            public List<MyCell> MyCellList;
    
            public MyPath(MyGrid gr) {
                this.myGrid = gr;
                this.MyCellList = new List<MyCell>(); }
    
            public void AddCellRecursive(MyCell c) {
                this.MyCellList.Add(c);
    
                var r = c.RightNeighbour;
                var b = c.BelowNeighbour;
    
                MyPath second=null;
    
                if (b == null && r == null)
                    return;//end
    
                else if (r == null) {
                    second = this;
                }
                else {
                    second = this.Clone();
                    this.myGrid.MyPathList.Add(second);
                    this.AddCellRecursive(r);
                }
    
                if (b == null)
                    this.myGrid.MyPathList.Remove(second);
                else 
                    second.AddCellRecursive(b);
                
            }
    
            public MyPath Clone(){
                var retPath = new MyPath(this.myGrid);
                foreach (var c in MyCellList) {
                    retPath.MyCellList.Add(c);
                }
                return retPath;
            }
        }
 
