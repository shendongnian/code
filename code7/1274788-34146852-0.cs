        public class DocumentSearch
        {
            public string searchTerm { get; set; }
            string myString = "this is a text string that I wanted to search through.";
            //This would be async if what I was trying was possible.
            public async Task<bool> SearchDoc(IProgress<double> progress)
            {
                int wordCount = myString.Split().Length;
                string[] words = myString.Split(' ');
                int counter = 0;
                foreach (string word in words)
                {
                    counter++;
                    if (word == searchTerm)
                    {
                        return true;
                    }
                    progress.Report((double)counter / (double)wordCount * 100);
                }
                return false;
            }
        }
