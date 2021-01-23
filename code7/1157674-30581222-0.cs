    var searchQuery = "John Doe Brazil";
    
                var searchWords = searchQuery
                    .Split(' ')
                    .Select(x => x.Trim()
                        .ToLower())
                    .Where(y => !string.IsNullOrWhiteSpace(y)).ToArray();
                User obj=new User()
                {
                    FirstName = "Ali",
                    LastName = "John"
                };
                var someParentObjects =new[]{ new Parent(){User =obj}};
               
    
                foreach (var searchWord in searchWords)
                {
                    var word = searchWord;
                  var ParentObjects = someParentObjects
                    .Where(x => x.User.FirstName.ToLower().Contains(word) ||
                    x.User
                    .LastName.ToLower().Contains(word) 
                   
                    );
                }
