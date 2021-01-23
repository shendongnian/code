    private void btnaddIPrange_Click(object sender, EventArgs e)
    {
        Form2 myForm = new Form2(); // Creates instance of Form2.
        myForm.Owner = this; // Assigns reference to this instance of Form1 to the Owner property of Form2.
        myForm.Show(); // Opens Form2 instance.
        // You can also call myForm.Show(this);
        // instead of the above two lines to automatically assign this form as the owner.
    }
