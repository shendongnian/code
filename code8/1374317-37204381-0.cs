         public   TextBox tbRandom =new TextBox() ;
         private void Form1_Load(object sender, EventArgs e)
        {
           this.Controls.Add(tbRandom);
        }
        public string TextBoxTxt {
        	get { return txtText1.Text; }
        	set { txtText1.Text = value; }
        }
    //Your button RandWord
    private void RandWord_Click(object sender, EventArgs e)
        {
           RandWord(this);
        } 
