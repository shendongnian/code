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
                 new ImageDemo{Title = "child", Name="dancing"}  ,
                 new ImageDemo{Title = "dancing", Name="child"}  ,
                 new ImageDemo{Name="dancing child"} ,
                 new ImageDemo{Title="dancing child"} 
            };
            var searchFuncs = target_keywords.Select(x =>
            {
                Func<ImageDemo, bool> func = (img) =>
                {
                    return (img.Title ?? string.Empty).Contains(x) || (img.Name ?? string.Empty).Contains(x);
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
