    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    namespace Books
    {
        abstract class Book // Class prototype for a book from a text file
        {
            public string bookTitle { get; set; } // the title
            public string bookSubTitle { get; set; } // subtitle
            public string bookAuthor { get; set; }  // author
            protected string[] bookText { get; set; } // book's text
            protected int totalPages { get; set; } // Total number of pages
            public Boolean loadError = false;     // file not found marker
            abstract internal void loadPages(); // seperates pages
            // Generic class constructor
            public Book(string filename)
            {
                if (File.Exists(filename)) // does text file book exist?
                    bookText = File.ReadAllLines(filename); //load bookText
                else
                {
                    loadError = true;// File was not found
                    ErrorMessage("File \"" + filename + "\" is missing.                             
                      \nClosing program.");
                }
            }
            // Displays an error message
            private static void ErrorMessage(string str)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(str);
                Console.ResetColor();
            }
            // Prototype class for a page
            protected abstract class Page
            {
                internal int pageNum { get; set; }
                internal string pageText { get; set;}
            }
        }
        // Class used specifically for the "Daily Reflections" book
        class DailyReflections : Book
        {
            List<dailyPage> dailypages = new List<dailyPage>();
            private DateTime today = DateTime.Now;
            // Organizes pages from bookText[] into dailypages list
            internal void loadPages()
            {
                DateTime date = new DateTime();
                DateTime date2 = new DateTime();
                string temptitle;
                StringBuilder str = new StringBuilder();
                for (int bookline = 0; bookline < bookText.LongLength;                    
                  bookline++)
                {
                    if (DateTime.TryParse(bookText[bookline], out date))
                    {
                        bookline++;
                        temptitle = bookText[bookline].Trim();
                        while (!DateTime.TryParse(bookText[bookline], out                         
                          date2))
                        {
                            str.AppendLine(bookText[bookline]);
                            if (++bookline >= bookText.LongLength) break;
                        }
                        bookline--;
                        dailypages.Add(new dailyPage());
                        dailypages[totalPages].pageDate = date;
                        dailypages[totalPages].pageText = str.ToString();
                        dailypages[totalPages].pageNum = totalPages + 1;
                        dailypages[totalPages].pageTitle = temptitle;
                        str.Clear();
                        totalPages++;
                    }
                }
            }
            // Class constructor unique to DailyReflections
            public DailyReflections() : base("Daily Reflections.txt")
            {
                this.bookTitle = "Daily Reflections";
                this.bookSubTitle = "";
                this.bookAuthor = "";
                loadPages();
            }
            // Display all lines of bookText
            public void printText()
            {
                foreach (dailyPage txt in dailypages)
                {
                    Console.WriteLine(txt);
                }
            }
            // Page[] unique to DailyReflections
            protected class dailyPage : Page
            {
                internal DateTime pageDate { get; set; }
                internal string pageTitle { get; set; }
            }
        }
    }
