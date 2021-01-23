    public interface IMlcWidgetInformation
    {
        int Sides { get; }
        int Hooks { get; }
        int Feathers { get; }
    }
    public class SmallWidgetInformation : IMlcWidgetInformation
    {
        public int Sides { get; } = 6;
        public int Hooks { get; } = 3;
        public int Feathers { get; } = 1;
    }
