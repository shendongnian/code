      public class Offender {
        ...
        public void Offend(YourClass value) {
          ...
          // In the middle of my routine I've ruined your class
          value.Data.Clear();
          value.Data.Add(someStuff);
          ...
        }
      }
