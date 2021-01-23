            foreach(var number in myList.ToArray())
            {
                if (number != 0)
                {
                    myList.AddRange(ATM(number));
                }
                else
                {
                    continue;
                }
