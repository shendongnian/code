        ...
        List<char> start = new List<char>();
        List<char> end = new List<char>();
        
        start = Increment(end);
        Increment(end);
        Increment(end);
        
        Excel.Range range = sheet.get_Range(new String(start.ToArray())+ "7", 
                                            new String(end.ToArray())+ "7");
    }
    private List<char> Increment(List<char> listColumn, int position=0)
    {
        if (listColumn.Count > position)
        {
            listColumn[position]++;
            if (listColumn[position] == '[')
            {
                listColumn[position] = 'A';
                Increment(listColumn, ++position);
            }
        }
        else
        {
                listColumn.Add('A');
        }
        return listColumn;
    }
