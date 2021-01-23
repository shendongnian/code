    private void homeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    if(x==1)//You know you are un page 1, you hide all the page 1 controls
    {
    button1.Visible = false;
    textbox1.Visible = false;
    label1.Visible = false;
    }
    else if(x==2)
    {
    //Hide you page 2 control, etc.
    }
    //After hidding your controls, next you have to show this page controls and adjust them to the form which are this ones:
    button2.Visible = true;
    textbox2.Visible = true;
    picturebox1.Visible = true;
    label2.Visible = true;
    button1.Location = new Point(X, Y);
    //Other controls locations...
    
    //Finally, set X the value of the page number so you can copy and paste te comparation os X above in your events of every page:
     X = pagenumber;
    }
