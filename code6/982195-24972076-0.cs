    public string genText(List<string> list)
    {
        StringBuilder text = new StringBuilder();
    	text.Append(@"{""text"":""");
        for (int i = 0; i < list.Count; i++)
        {
            if (i < list.Count - 1)
                text.Append("!" + " ");
        ...
        return text.ToString();
    }
