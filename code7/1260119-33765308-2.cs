    class Subscription {
      public Round Round { get; set; }
      public Student Student { get; set; }
    }
    abstract class IDIdentity {
      public int ID { get; set; }
    }
    class Workshop : IDIdentity {
      public string Name { get; set; }
    }
    class Round : IDIdentity {
      public Workshop Workshop { get; set; }
      public DateTime StartsAt { get; set; }
      public DateTime EndsAt { get; set; }
      public int AvailableSpace { get; set; }
    }
    class Student : IDIdentity {
      public string Name { get; set; }
    }
