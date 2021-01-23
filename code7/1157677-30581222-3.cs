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
                var someParentObjects =new[]{ new Parent(){Users =obj}};
               
    
                foreach (var searchWord in searchWords)
                {
                    var word = searchWord;
                  var ParentObjects = someParentObjects
                    .Where(x => x.Users.FirstName.ToLower().Contains(word) ||
                    x.Users
                    .LastName.ToLower().Contains(word) 
                   
                    );
                }
