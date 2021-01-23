    class ImageDemo
            {
                public string Title { get; set; }
                public string Name { get; set; }
            }
    
            static void TestCode()
            {
                List<string> target_keywords = new List<string>(){"dancing","child"};
                List<ImageDemo> images = new List<ImageDemo>()
                {  
                    new ImageDemo{Title = "dancing"}  ,
                     new ImageDemo{Name = "child"}  ,
                     new ImageDemo{Name="dancing child"} 
                };
                var searchFuncs = target_keywords.Select(x =>
                {
                    Func<ImageDemo, bool> func = (img) =>
                    {
                        string txt = img.Title ?? (img.Name ?? string.Empty);
                        return txt.Contains(x);
                    };
                    return func;
                });
                IEnumerable<ImageDemo> result = images;
                foreach (var func in searchFuncs)
                {
                    result = result.Where(x => func(x));
                }
                foreach (var img in result)
                {
                    Console.WriteLine(string.Format("Title:{0}  Name:{1}", img.Title, img.Name));
                }
            }
