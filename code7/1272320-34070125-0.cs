    Random rng = new Random();
    Stack<String> shoe = new Stack<string>();
    private void button1_Click(...
    {
        if (shoe.Count == 0)
        {
            // refill when empty
            shoe = new Stack<string>(GetNewValues());
        }
        // display next, remove from "deck"
        lb1.Items.Add(shoe.Pop());
    }
    private string[] GetNewValues()
    {
        string[] values = { "value1", "value2", "value3", 
                            "value4", "value5" };
        //simple, usually-good-enough randomizer
        return values.OrderBy(r => rng.Next()).ToArray();
    }
