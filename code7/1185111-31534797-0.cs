            string wordString = "(Four)";
            string sentenceString = "Maybe the fowl of Uruguay repeaters (Four) will be found";
            //Additionally you can add splitoption to remove the empty word on split function bellow
            //Just in case there are more space in sentence.
            string[] splitedword = sentenceString.Split(' ');
            int tempBackposition = 0;
            int finalposition = 0;
            for (int i = 0; i < splitedword.Length; i++)
            {
                if (splitedword[i].Contains(wordString))
                {
                    finalposition = i;
                    break;
                }
            }
            tempBackposition = finalposition - wordString.Replace("(","").Replace(")","").Length;
            string output = "";
            tempBackposition= tempBackposition<0?0:tempBackposition;
            for (int i = tempBackposition; i < finalposition; i++)
            {
                output += splitedword[i] + " ";
            }
            Console.WriteLine(output);
            Console.ReadLine();
