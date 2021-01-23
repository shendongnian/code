        public string GetNextElement(IList<string> list, int index)
        {
            if ((index > list.Count - 1) || (index < 0))
                throw new Exception("Invalid index");
            else if (index == list.Count - 1)
                index = 0;
            else
                index++;
            return list[index];
        }
