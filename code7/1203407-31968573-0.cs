            List<string>myStringList= new List<string>();
              string prevID= myStringList.First().Substring(0,8);
            foreach (string textLine in myStringList)
            {
                //Get the first 8 characters of the string (ID numbers)
                string aNumber = textLine.Substring(0, 8);
                if (aNumber.Equals(prevID))
                {
                    //do whatever you want with them.
                }
                else
                {
                }
                prevID= aNumber ;
            }
