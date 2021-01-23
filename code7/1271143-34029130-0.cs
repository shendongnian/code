    public interface ISetting
    {
        string Name { get; set; }
    }
    public class Setting<T> : ISetting
        where T : struct
    {
        public string Name { get; set; }
        public T Value { get; set; }
    }
    public class SettingsDto
    {
        public List<ISetting> Settings { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var set=new SettingsDto();
            set.Settings=new List<ISetting>();
            set.Settings.Add(new Setting<int>() { Name="Setting1", Value=100 });
            set.Settings.Add(new Setting<double>() { Name="Setting2", Value=Math.PI });
            set.Settings.Add(new Setting<DateTime>() { Name="Setting3", Value=DateTime.Now });
            set.Settings.Add(new Setting<int>() { Name="Setting4", Value=200 });
            foreach(var setting in set.Settings.OfType<Setting<int>>())
            {
                Console.WriteLine("{0}={1}", setting.Name, setting.Value);
            }
            // Setting1=100
            // Setting4=200
        }
    }
