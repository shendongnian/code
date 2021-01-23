    private bool compareStrings()
        {
            string stringLeft = "Hello! My name is Alex Jolig. Its nice to meet you.";
            string stringRight = "My name is Alex. Nice to meet you.";
            List<string> liLeft = stringLeft.Split(' ').ToList();
            List<string> liRight = stringRight.Split(' ').ToList();
            double totalWordCount = liLeft.Count();
            double matchingWordCount = 0;
            foreach (var item in liLeft)
	        {
		        if(liRight.Contains(item)){
                    matchingWordCount ++;
                }
	        }
            //return bool based on percentage of matching words
            return ((matchingWordCount / totalWordCount) * 100) >= 50;
        }
