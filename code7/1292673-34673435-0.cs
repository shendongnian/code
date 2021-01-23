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
