    protected void sem_1_cat_Click(object sender, EventArgs e)
    {
        int cattotal;
        int catselected;
        int catcalc;
    
        for (int i = 0; i < module_semester_1.Items.Count; i++)
        {
            if (module_semester_1.Items[i].Selected)
            {
                string value = module_semester_1.Items[i].Value;
    
                cattotal = int.Parse(cat_points_total.SelectedValue);
                catselected += int.Parse(value);
                catcalc = cattotal - catselected;
    
                sem_1_fb.Visible = true;
                sem_1_fb.Text = "cattotal =" + cattotal + " catselected =" +
                                catselected + " catcalc =" + catcalc + ".";
            }
        }
    }
