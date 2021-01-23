    list<string> listBeforeEmpty = new list<string>();
    list<string> listAfterEmpty = new list<string>();
    //Indicates whether the loop is before the empty line or not
    bool isEmptyLineFound = false;
     for (int i = 0; i < lines.Length; i++)
        {
         //If the empty line was found
         if (lines[i].CompareTo(@"") == 0)
        		{
        			isEmptyLineFound = true;
        		}
        //Add the line to the right list
         if (isEmptyLineFound == false) 
              listBeforeEmpty .Add(lines[i]);
         else listAfterEmpty .Add(lines[i]);
        }
