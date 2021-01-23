    private void MultipleReplace(string text, string[] oldValues, string[] newValues)
    {
        for (int i = 0; i < old.Length; i++)
        {
            text = text.replace(oldValues[i], newValues[i]);
        }
    }
