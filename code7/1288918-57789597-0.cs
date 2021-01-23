    public class CustomObjectDto
    {
        public int ID { get; set; }
        // ... other props
        public Color ColorID { get; set; }
        public ColorDto ColorDto { get; set; }
    }
    public class ColorDto
    {
        public Color ID { get; set; }
        public string Name { get; set; }
    }
