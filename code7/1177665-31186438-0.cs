        public void getString(string[] anyString)
        { 
            foreach (var element in anyString.Where(el => !string.IsNullOrEmpty(el)))
            {
                if (element == "item1")
                {
                    myOtherMethod(element);
                }
                else if (element == "item2")
                {
                    myOtherMethod(element);
                }
                else if (element == "item3")
                {
                    myOtherMethod(element);
                }
            }
        }
        public void myOtherMethod(string anyString)
        {
             //do whatever with the string you got.
        }
