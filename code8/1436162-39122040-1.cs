    public Dictionary<string, List<string>> myBookList = new Dictionary<string, List<string>>();
        private void addList(string listName, List<string> contents)
        {
            myBookList.Add(listName, contents);
            //direct add
            List<string> science_Fiction_Books = new List<string>();
            myBookList.Add("Science Fiction", science_Fiction_Books);
            myBookList["Science_Fiction"].Add("mytitle.txt");
            myBookList["Science_Fiction"][0] = "My book title.txt";
            string fileLocation = @"c:\mydirectory\mylists\myBookTitle.txt";
            myBookList["Science_Fiction"].Add(System.IO.Path.GetFileName(fileLocation));
            //etc.
        }
