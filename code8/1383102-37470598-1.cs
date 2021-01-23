    public void devMessage(string m)
    {
    Text t = GameObject.Find("devText").GetComponent<Text>();
    t.text = t.text +"\n" +m
    }
