    private static void Main(string[] args)
        {
            var programmingCategory = new Category {CategoryName = "Programming"};
    
            var ciProgramming = new CategoryItem
            {
                Link = "www.stackoverflow.com"
            };
    
            var fooCategory = new CategoryItem
            {
                Link = "www.foo.com"
            };
            programmingCategory.Items.Add(ciProgramming);
            programmingCategory.Items.Add(fooCategory);
    
            var serializer = new XmlSerializer(typeof (Category));
            var file = new FileStream(FILENAME, FileMode.Create);
            serializer.Serialize(file, programmingCategory);
            file.Close();
        }
