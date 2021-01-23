        public Usuario()
        {
          InitializeComponent();
        }
         private string _Message;
         public string Message
         {
           get { return _Message; }
           set { _Message = value; }
         }
     private void button1_Click(object sender, EventArgs e)
     {
        if (!string.IsNullOrEmpty(textBox1.Text))
        {
            Jugador jug = new Jugador();
            jug.Traemelo(textBox1.Text);
            Message = textBox1.Text;
            elegirTipo us = new elegirTipo();
            us.Show();
            this.Hide();
        }
    }
