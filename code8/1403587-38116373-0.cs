    List<int> values = new List<int>();
    private void CheckCondition()
    {
        bool flag = false;
        for (int i = 0; i < 5; i++)
        {
            int idx = values.FindIndex(item => item == i || item > i);
            if(idx == -1)
            {
               values.Add(i);
               break;
            }
        }
    }
