    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Setting> settings = new List<Setting>() {
                    new Setting() { name = "Trigger Burst Enabled", order = 1},
                    new Setting() { name = "Rcs Start After", order = 2},
                    new Setting() { name = "Trigger RCS", order = 4},
                    new Setting() { name = "Trigger Burst Shots", order = 5},
                    new Setting() { name = "Trigger Key", order = 7},
                    new Setting() { name = "Rcs Force Max", order = 4},
                    new Setting() { name = "Trigger Toggle", order = 3},
                    new Setting() { name = "Trigger Delay FirstShot", order = 4},
                    new Setting() { name = "Rcs Enabled", order = 5},
                    new Setting() { name = "Trigger Allies", order = 6},
                    new Setting() { name = "Trigger Enemies", order = 7},
                    new Setting() { name = "Trigger Enabled", order = 8},
                    new Setting() { name = "Rcs Force Min", order = 6},
                    new Setting() { name = "Trigger Hold", order = 3},
                    new Setting() { name = "Trigger Delay Shots", order = 4}
                };
                List<string> names = settings.OrderBy(x => x.order).Select(y => y.name).ToList();
            }
        }
        public class Setting
        {
            public string name { get; set; }
            public int order { get; set; }
        }
    }
    ​
