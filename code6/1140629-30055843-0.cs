    public void NeemOp(int bedrag, ListBox listBox)
        {
                // bedrag in hele centen, negatieve bedragen worden genegeerd.
                // vul zelf in
                if (bedrag <= saldo) 
                {
                    this.saldo = this.saldo - bedrag;
                    listBox.Items.Add(saldo);
    
                }
                else
                {
                    MessageBox.Show("Onvoldoende saldo.");
                }
                                   
        }
