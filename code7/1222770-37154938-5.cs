    class Container {
        public Container(int x, int y, int width, int height) {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public int ShortestEdge => Math.Min(Width, Height);
        public IDictionary<TreemapItem, Rectangle> GetCoordinates(TreemapItem[] row) {
            // getCoordinates - for a row of boxes which we've placed 
            //                  return an array of their cartesian coordinates
            var coordinates = new Dictionary<TreemapItem, Rectangle>();
            var subx = this.X;
            var suby = this.Y;
            var areaWidth = row.Select(c => c.Area).Sum()/(float) Height;
            var areaHeight = row.Select(c => c.Area).Sum()/(float) Width;
            if (Width >= Height) {
                for (int i = 0; i < row.Length; i++) {
                    var rect = new Rectangle(subx, suby, (int) (subx + areaWidth), (int) (suby + row[i].Area/areaWidth));
                    // do not allow width\height to overflow bounding box
                    // this
                    if (rect.X + rect.Width > this.X + this.Width) {
                        rect.Width = this.X + this.Width - rect.X;
                    }
                    if (rect.Y + rect.Height > this.Y + this.Height) {
                        rect.Height = this.Y + this.Height - rect.Y;
                    }
                    coordinates.Add(row[i], rect);
                    suby += (int) (row[i].Area/areaWidth);
                }
            }
            else {
                for (int i = 0; i < row.Length; i++) {
                    var rect = new Rectangle(subx, suby, (int) (subx + row[i].Area/areaHeight), (int) (suby + areaHeight));
                    // do not allow width\height to overflow bounding box
                    if (rect.X + rect.Width > this.X + this.Width) {
                        rect.Width = this.X + this.Width - rect.X;
                    }
                    if (rect.Y + rect.Height > this.Y + this.Height) {
                        rect.Height = this.Y + this.Height - rect.Y;
                    }
                    coordinates.Add(row[i], rect);
                    subx += (int) (row[i].Area/areaHeight);
                }
            }
            return coordinates;
        }
        public Container CutArea(int area) {
            // cutArea - once we've placed some boxes into an row we then need to identify the remaining area, 
            //           this function takes the area of the boxes we've placed and calculates the location and
            //           dimensions of the remaining space and returns a container box defined by the remaining area
            if (Width >= Height) {
                var areaWidth = area/(float) Height;
                var newWidth = Width - areaWidth;
                return new Container((int) (X + areaWidth), Y, (int) newWidth, Height);
            }
            else {
                var areaHeight = area/(float) Width;
                var newHeight = Height - areaHeight;
                return new Container(X, (int) (Y + areaHeight), Width, (int) newHeight);
            }
        }
    }
