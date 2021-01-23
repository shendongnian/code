    private T RetrieveItem<T>(IList<T> list) where T : Component
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].gameObject.activeInHierarchy)
            {
                return list[i];
            }
        }
        return list[0];
    }
