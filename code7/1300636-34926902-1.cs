    public class User {
         int? RedGroupId { get; protected set; }    // int -> int?
         RedGroup RedGroup { get; protected set; }  // virtual missing, but shouldn't matter
         // Other properties
    }
