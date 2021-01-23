    using System;
    using System.Collections.Concurrent;
    
    
    namespace TestArea
    {
        public class Pupil
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
    
            public string UserName { get; set; }        
        }
    
        public class Book
        {
            //Supports having more than one ISBN in the library... We may have more than one To Kill a Mockingbird in our school library
            public Guid Id { get; set; }
            public string ISBN { get; set; }
        }
        public class SchoolLibrary
        {
            private ConcurrentDictionary<Guid, Pupil> Pupils { get; set; }
            private ConcurrentDictionary<Guid, Book> Books{ get; set; }
            private ConcurrentDictionary<Guid, Guid> CheckOuts { get; set; }
    
            public Pupil Login(string userName, string password)
            {
                //Call repository to authenticate pupil into library system
    
                //Mocked return assuming password check success
                var id = Guid.NewGuid();
                
                return Pupils.GetOrAdd(id, (i) =>
                {
                    //Replace with function to get student info
                    return new Pupil
                    {
                        Id = i,
                        Name = "Bac Clunky",
                        UserName = userName
                    };
                });
            }
    
            public bool CheckOut(Guid pupilId, Guid bookId)
            {
                //If book exists
                if (Books.ContainsKey(bookId))
                {
                    Guid currentOwner;
                    //...is not currently checked out by anyone
                    if (CheckOuts.TryAdd(bookId, pupilId))
                    {
                        return true; //book is now checked out
                    }
    
                    if (CheckOuts.TryGetValue(bookId, out currentOwner))
                    {
                        return currentOwner == pupilId; //returns true if pupil already has the book, false if another student has it
                    }                    
                }
    
                return false; //all other cases fail to check out book
            }
        }
    }
