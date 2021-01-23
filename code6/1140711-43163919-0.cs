        static void Main(string[] args)
            {
                List<Entity> testList = new List<Entity>()
                {
                    new Entity() {Id = 1, Text = "Text"},
                    new Entity() {Id = 2, Text = "Text2"}
                };
    
                Console.WriteLine($"First text value:{testList[1].Text}");
    
                Entity entityToEdit = testList.FirstOrDefault(e => e.Id == 2);
                if (entityToEdit != null)
                    entityToEdit.Text = "Hello You!!";
    
                Console.WriteLine($"Edited text value:{testList[1].Text}");
                
                Console.ReadLine();
            }
    
     internal class Entity
        {
            public int Id { get; set; }
            public String Text { get; set; }
        }
