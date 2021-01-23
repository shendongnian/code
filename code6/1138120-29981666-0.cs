    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonFullName { get { return FirstName + " " + LastName; } }
        public TextDecorationCollection PersonTextDecorations
        {
            get
            {
                if (FirstName == "George")
                {
                    return new TextDecorationCollection() 
                        { 
                            new TextDecoration
                                (
                                TextDecorationLocation.Strikethrough,
                                new Pen(Brushes.Red, 1), 
                                0, 
                                TextDecorationUnit.Pixel, 
                                TextDecorationUnit.Pixel
                                ) 
                        };
                }
                else
                {
                    return null;
                }
            }
        }
    }
