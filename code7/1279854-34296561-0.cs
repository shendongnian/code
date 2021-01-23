    private void update_Click(object sender, EventArgs e)
    {
        string Name = nameTxt.Text;
        int Age = Convert.ToInt32(AgeTxt.Text);
    
        Dog dg = new Dog(Name , Age );
        dg.update();
    }
