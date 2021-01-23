    private void LettersPanel_Load(object sender, EventArgs e)
    {
        foreach (var letter in collection)
        {
            // get all labels and suscribe each one to a single private event
            letter.MouseDown += new MouseEventHandler(Letters_MouseDown);
        }
    
        // public event
        //this.LetterClick += Letters_MouseDown; //remove this line
    }
