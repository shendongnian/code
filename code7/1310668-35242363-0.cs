     static void exampleFunction()
        {
            const int MAXNUM = 20; //The max amount of elements in the second array strings.
            int count = 0;
            int secondCount = 0;
            string text = "aaa 'bbb c' dd ee fg hjj";
            string[] firstTextSplitted = { "" };
            string[] secondTextSplitted = new string[MAXNUM];
            firstTextSplitted = text.Split('\''); //We obtain the following strings: "aaa", "bbb c" and "dd ee fg hjj".
            for (count = 0; count < 3; count++) //We obtain separately the three strings from the first string array.
            {
                if (count == 2) //If we are in the last one, we must split it again and store each element in the followings.
                {
                    secondCount = count;
                    foreach (string element in firstTextSplitted[count].Split(' '))
                    {
                        secondTextSplitted[secondCount] = element;
                        secondCount++;
                    }
                }
                else
                {
                    secondTextSplitted[count] = firstTextSplitted[count];
                }
            }
            foreach (string element in secondTextSplitted) //We print each string value from the second string array, if we dont match a null value.
            {
                if (element != null)
                {
                    Console.WriteLine(element);
                }
            }
        }
