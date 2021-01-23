    public class Thing {
        public string ip;
    }
    var list = new List<Thing>() {
        new Thing() { ip = "192.168.1.1" },
        new Thing() { ip = "192.168.1.10" },
        new Thing() { ip = "192.168.1.2" },
        new Thing() { ip = "192.168.1.254" },
        new Thing() { ip = "192.168.1.3" }
    };
    var sorted = list.OrderBy(item => Version.Parse(item.ip));
    foreach (var item in sorted) {
        Console.WriteLine(item.ip);
    }
