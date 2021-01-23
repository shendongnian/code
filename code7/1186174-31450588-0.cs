        public interface IMenu
        {
            int a { get; set; }
            string b {get; set; }
        }
        public class SubMenu : IMenu
        {
            public int a { get; set; }
            public string b { get; set; }
            public double c { get; set; }
        }
        public class MainMenu : IMenu
        {
            public int a { get; set; }
            public string b { get; set; }
            public string d { get; set; }
        }
