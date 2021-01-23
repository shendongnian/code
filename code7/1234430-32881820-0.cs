      public class Foo {
        // Settings should be read and then preserved intact
        public static readonly String Settings = File.ReadAllText(@"C:\MySettings.txt");
        ...
      }
