    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestArea.Other
    {
        public class Author : IComparable<Author>
        {
            public string Name { get; set; }
            
            public int CompareTo(Author other) => this.Name.CompareTo(other.Name);
        }
    
        public class Authors :  ReadOnlyCollection<Author>, IEquatable<Authors>
        {
            public Authors(IList<Author> list) : base(list)
            {
    
            }
    
            public bool Equals(Authors other)
            {
                //reference equal 
                if (other == this)
                {
                    return true;
                }
    
                //No need to iterate over authors
                if (other == null || other.Count != this.Count)
                {
                    return false;
                }
    
                var thisSorted = this.ToArray();
                var otherSorted = other.ToArray();
                Array.Sort(thisSorted);
                Array.Sort(otherSorted );
    
                for (int i = 0; i < thisSorted.Length; i++)
                {
                    if (thisSorted[i].CompareTo(otherSorted[i]) != 0)
                    {
                        return false;
                    }
                }
    
                return true;
            }
        }
    
        public class Book : IEquatable<Book>
        {
    
            public string bookTitle { get; private set; }
            public Authors authors { get; private set; }
            public string ISBN { get; private set; }
            public int numberofpages { get; private set; }
            public string Genre { get; private set; }
    
            //Made Authors parameter as simplified as it could be
            public Book(string bookTitle, IEnumerable<Author> authors, string ISBN, int numberofpages, string genre)
            {
                var authorList = authors.ToList();
                if (string.IsNullOrWhiteSpace(bookTitle))
                {
                    throw new ArgumentNullException("Book Must Have Title!");
                }
                this.bookTitle = bookTitle;
    
                if (authorList.Count() < 0)
                {
                    throw new ArgumentNullException("You must provide at least one author!");
                }
                this.authors = new Authors(new List<Author>(authorList));
    
                if (String.IsNullOrWhiteSpace(ISBN))
                {
                    throw new ArgumentNullException("A Book Has to have an ISBN number. Check online or the back cover");
                }
                this.ISBN = ISBN;
                if (numberofpages <= 0)
                {
                    throw new ArgumentNullException("A Book has more than one page!");
                }
                this.numberofpages = numberofpages;
                if (String.IsNullOrWhiteSpace(genre))
                {
                    throw new ArgumentNullException("A Book has a genre. Find it and input it");
                }
                this.Genre = genre;
            }
    
    
            public override bool Equals(Object obj)
            {
                if (obj == null)
                {
                    return false;
                }
    
                Book p = obj as Book;
                if ((System.Object) p == null)
                {
                    return false;
                }
                return (bookTitle == p.bookTitle) && (authors.Equals( p.authors)) && (numberofpages == p.numberofpages) &&
                       (ISBN == p.ISBN) && (Genre == p.Genre);
            }
    
            public bool Equals(Book p)
            {
                if ((object) p == null)
                {
                    return false;
                }
    
                return (bookTitle == p.bookTitle) && (authors.Equals( p.authors)) && (numberofpages == p.numberofpages) &&
                       (ISBN == p.ISBN) && (Genre == p.Genre);
            }
        }
    }
