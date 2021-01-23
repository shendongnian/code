    private void btnDetails_Click(object sender, EventArgs e)
    {        
        Ticket t = cbEvents.SelectedItem as Ticket;
        if (t !=null)
        {
                //Display details
                lblDetails.Text = t.getDetails();
                //Display image
                displayImage(t.getFileName());            
        }
    }
