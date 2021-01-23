    public enum WidgetType { }
    public class Claculator { }
    public class WeightStore
    {
        static Dictionary<int, double> widgetWeightedAvg = new Dictionary<int, double>();
        public static void AttWeightedAvgAvailable(double attwightedAvg, int widgetid)
        {
            if (widgetWeightedAvg.Keys.Contains(widgetid))
                widgetWeightedAvg[widgetid] += attwightedAvg;
            else
                widgetWeightedAvg[widgetid] = attwightedAvg;
        }
    }
    public class WidgetAttribute
    {
        public string Name { get; }
        public double Value { get; }
        public WidgetAttribute(string name, double value, WidgetType type, int widgetId)
        {
            Name = name;
            Value = value;
            double attWeight = Calculator.Weights[type][name];
            WeightStore.AttWeightedAvgAvailable(Value*attWeight, widgetId);
        }
    }
    public class CogWdiget
    {
        public int Id { get; }
        public WidgetAttribute height { get; set; }
        public WidgetAttribute wight { get; set; }
    }
    public class Client
    {
        public void BuildCogWidgets()
        {
            CogWdiget widget = new CogWdiget();
            widget.Id = 1;
            widget.height = new WidgetAttribute("height", 12.22, 1);
        }
    }
