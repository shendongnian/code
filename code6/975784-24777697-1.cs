    public FormA nv;
    
        Public FormB(FormA formA)
        {
            nv = formA;
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            if (nv.button6WasClicked)
            { 
                ..........
                nv.button6WasClicked = false;
            }
        }
