    public virtual void removeRepeat()
    {
        IEnumerator<string> iterator = words.GetEnumerator();
        string checkWord = null;
        List<int> removeIndexes = new List<int>();
        
        int i = -1;
        while (iterator.MoveNext())
        {
            checkWord = iterator.Current;
            i++;
            foreach (string tmpWord in words)
            {
                if (tmpWord.Contains(checkWord) && checkWord.Length < tmpWord.Length)
                {
                    removeIndexes.Add(i);
                    break;
                }
            }
        }
        removeIndexes.Reverse();
        foreach(var index in removeIndexes) {
            words.RemoveAt(index);
        }
    }
