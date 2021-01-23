    public StyleVisibleOfControls Style
    { 
        set{
            // you can use switch too
            if ( value ==StyleVisibleOfControls.Style1 )
            {
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
            }
            else if (value ==StyleVisibleOfControls.Style2){
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
            }
        }
    }
