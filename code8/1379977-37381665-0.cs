    LbAnimals.DisplayMember = "name"; // this sets tge property of the object that would be displayed to name.
    private void Update()
    {
            lbAnimals.Items.Clear();
            lbAnimals.Items.Clear();
            foreach (Cat c in reservations.Cats)
        {
            lbAnimals.Items.Add(c);
        }
        foreach (Dog d in reservations.Dogs)
        {
            lbAnimals.Items.Add(d);
        }
    } 
            private void btnReserveDog_Click(object sender, EventArgs e)
               { 
                  if (this.reservations.Dog != null)
                { 
                    //you also missed a null check here, this might raise an exception if no item is selected in the listbox
               If ( lbAnimals.SelectedItem !=null)
                   {
                     Dog  d=  lbAnimals.SelectedItem as Dog; 
                    d.Reserve(txtReservor.Text); 
                    this.btnReserveDog.Enabled = false;
                    Update();
                   }
               }
            } 
