    void Main()
    {
        const int pegCount = 3;
        const int ringCount = 8;
    
        var pegs = Enumerable.Range(1, pegCount).Select(_ => new Peg()).ToList();
    
        foreach (var ring in Enumerable.Range(1, ringCount).Select(width => new Ring(ringCount + 1 - width)))
            pegs[0].Push(ring);
    
        DrawPegs(pegs);
        MoveRing(pegs[0], pegs[1]);
        DrawPegs(pegs);
    }
    
    public void MoveRing(Peg fromPeg, Peg toPeg)
    {
        toPeg.Push(fromPeg.Pop());
    }
    
    public class Peg : Stack<Ring>
    {
    }
    
    public struct Ring
    {
        public int Width { get; }
        public Ring(int width) { Width = width; }
    }
    
    public void DrawPegs(IEnumerable<Peg> pegs)
    {
        var bitmaps = pegs.Select(peg => DrawPeg(peg));
        Util.HorizontalRun(true, bitmaps).Dump();
    }
    
    public Bitmap DrawPeg(Peg peg)
    {
        const int width = 200;
        const int height = 300;
        const int pegWidth = 6;
        const int ringHeight = 20;
        const int ringWidthFactor = 10;
        const int ringGapHeight = 3;
    
        var result = new Bitmap(width, height);
        using (var g = Graphics.FromImage(result))
        {
            g.Clear(Color.White);
    
            g.FillRectangle(Brushes.Black, width / 2 - pegWidth/2, 0, pegWidth, height);
            int y = height;
            foreach (var ring in peg.Reverse())
            {
                y -= ringHeight;
                g.FillRectangle(Brushes.Blue, width / 2 - ring.Width * ringWidthFactor, y, 2 * ring.Width * ringWidthFactor, ringHeight);
                y -= ringGapHeight;
            }
        }
        return result;
    }
