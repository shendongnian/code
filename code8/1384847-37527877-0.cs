    public class LineSegmentVisual : SegmentVisual
    {
        new LineSegment Owner { get { return (LineSegment)base.Owner; } }
        public LineSegmentVisual(Segment owner)
            : base(owner)
        {
        }
    
        public override void RedrawItself()
        {
            using (DrawingContext ctx = this.RenderOpen())
            {
                var owner = this.Owner;
                ctx.DrawLine(owner.Stroke, this.Owner.Position, this.Owner.ControlPointPos);
            }
        }
    }
