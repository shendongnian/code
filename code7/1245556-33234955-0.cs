    List<Roles> existing = new List<Roles>
    {
        new Roles(1, "admin", true),
        new Roles(2, "hr", false),
        new Roles(3, "it", true)
    };
    List<Roles> available = new List<Roles>
    {
        new Roles(1, "admin", true),
        new Roles(2, "hr", false),
        new Roles(3, "it", true),
        new Roles(4, "finance", false)
    };
    bool isUsersUpdated = !existing.Except(available).Any();
    Console.WriteLine(isUsersUpdated);
    // modified Roles class
    class Roles
    {
        public int Serial { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Roles(int serial, string name, bool isActive)
        {
            Serial = serial;
            Name = name;
            IsActive = isActive;
        }
        public override bool Equals(object obj)
        {
            Roles other = obj as Roles;
            if (other == null)
                return false;
            return Serial == other.Serial && Name == other.Name && IsActive == other.IsActive;
        }
        public override int GetHashCode()
        {
            return new { Serial, Name, IsActive }.GetHashCode();
        }
    }
