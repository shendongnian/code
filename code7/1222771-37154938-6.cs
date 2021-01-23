    public class Treemap {
        public Bitmap Build(TreemapItem[] items, int width, int height) {
            var map = BuildMultidimensional(items, width, height, 0, 0);
            var bmp = new Bitmap(width, height);
            var g = Graphics.FromImage(bmp);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            foreach (var kv in map) {
                var item = kv.Key;
                // fill rectangle
                g.FillRectangle(item.FillBrush, kv.Value);
                // draw border
                g.DrawRectangle(new Pen(item.BorderBrush, 1), kv.Value);
                if (!String.IsNullOrWhiteSpace(item.Label)) {
                    // draw text
                    var format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    var font = new Font("Arial", 16);
                    g.DrawString(item.Label, font, item.TextBrush, new RectangleF(kv.Value.X, kv.Value.Y, kv.Value.Width, kv.Value.Height), format);
                }
            }
            return bmp;
        }
        private Dictionary<TreemapItem, Rectangle> BuildMultidimensional(TreemapItem[] items, int width, int height, int x, int y) {
            var results = new Dictionary<TreemapItem, Rectangle>();
            var mergedData = new TreemapItem[items.Length];
            // here we assume that hierarhcy is of the same depth everywhere
            if (items[0].Children?.Length > 0) {
                // if there is next level of hierarchy
                for (int i = 0; i < items.Length; i++) {
                    // calculate total area of children - current item's area is ignored
                    mergedData[i] = SumChildren(items[i]);
                }
                // build a map for this merged items (merged because their area is sum of areas of their children)
                var mergedMap = BuildFlat(mergedData, width, height, x, y);
                for (int i = 0; i < items.Length; i++) {
                    var mergedChild = mergedMap[mergedData[i]];
                    // inspect children of children in the same way
                    foreach (var kv in BuildMultidimensional(items[i].Children, mergedChild.Width - mergedChild.X, mergedChild.Height - mergedChild.Y, mergedChild.X, mergedChild.Y)) {
                        results.Add(kv.Key, kv.Value);
                    }
                }
            }
            else {
                // if we are on the leaves and no more children items in hierarchy - just build regular map
                results = BuildFlat(items, width, height, x, y);
            }
            return results;
        }
        private Dictionary<TreemapItem, Rectangle> BuildFlat(TreemapItem[] items, int width, int height, int x, int y) {
            // normalize all area values for given width and height
            Normalize(items, width*height);
            var result = new Dictionary<TreemapItem, Rectangle>();
            Squarify(items, new TreemapItem[0], new Container(x, y, width, height), result);
            return result;
        }
        private void Normalize(TreemapItem[] data, int area) {
            var sum = data.Select(c => c.Area).Sum();
            var multi = area/(float) sum;
            foreach (var item in data) {
                item.Area = (int) (item.Area*multi);
            }
        }
        private void Squarify(TreemapItem[] data, TreemapItem[] currentRow, Container container, Dictionary<TreemapItem, Rectangle> stack) {
            if (data.Length == 0) {
                foreach (var kv in container.GetCoordinates(currentRow)) {
                    stack.Add(kv.Key, kv.Value);
                }
                return;
            }
            var length = container.ShortestEdge;
            var nextPoint = data[0];            
            if (ImprovesRatio(currentRow, nextPoint, length)) {
                currentRow = currentRow.Concat(new[] {nextPoint}).ToArray();
                Squarify(data.Skip(1).ToArray(), currentRow, container, stack);
            }
            else {
                var newContainer = container.CutArea(currentRow.Select(c => c.Area).Sum());
                foreach (var kv in container.GetCoordinates(currentRow)) {
                    stack.Add(kv.Key, kv.Value);
                }
                Squarify(data, new TreemapItem[0], newContainer, stack);
            }
        }
        private bool ImprovesRatio(TreemapItem[] currentRow, TreemapItem nextNode, int length) {
            // if adding nextNode 
            if (currentRow.Length == 0)
                return true;
            var newRow = currentRow.Concat(new[] {nextNode}).ToArray();
            var currentRatio = CalculateRatio(currentRow, length);
            var newRatio = CalculateRatio(newRow, length);
            return currentRatio >= newRatio;
        }
        private int CalculateRatio(TreemapItem[] row, int length) {
            var min = row.Select(c => c.Area).Min();
            var max = row.Select(c => c.Area).Max();
            var sum = row.Select(c => c.Area).Sum();
            return (int) Math.Max(Math.Pow(length, 2)*max/Math.Pow(sum, 2), Math.Pow(sum, 2)/(Math.Pow(length, 2)*min));
        }
        private TreemapItem SumChildren(TreemapItem item) {
            int total = 0;
            if (item.Children?.Length > 0) {
                total += item.Children.Sum(c => c.Area);
                foreach (var child in item.Children) {
                    total += SumChildren(child).Area;
                }
            }
            return new TreemapItem(item.Label, total, item.FillBrush);
        }
    }
