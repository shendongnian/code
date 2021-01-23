    // I would name it 'IsAscending' 
    // but the naming does not matter regarding speed just a comment
    static bool IsAscending(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] > list[i + 1])
            {
                // At this point we immediately return
                // so that the remaining elements in the list will not be checked
                return false;
            }
        }
        return true;
    }
