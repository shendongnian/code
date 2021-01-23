    private bool ChangeKey(string oldKey, string newKey, string value) {
        if (dictionary.ContainsKey(oldKey))
        {
            dictionary.Remove(oldKey);
            dictionary.Add(newKey, value);
            return true;
        }
        else return false;
    }
