    private void Form1_Load(object sender, EventArgs e)
    {
        FlowLayoutPanel flp = new FlowLayoutPanel();
        for (int i = 0; i < pits.numOfPits(); ++i)
        {
            Button btn = new Button();
            btn.Width = 160;
            btn..Height = 80; //set padding or margin to appropriate values
            flp.Controls.Add(btn);
        }
        this.Controls.Add(flp);
    }
