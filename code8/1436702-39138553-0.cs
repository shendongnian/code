    List<Ticket> allTickets = ...
    private void btnTktDelete_Click(object sender, EventArgs e)
    {
        Ticket ticketToRemove = (Ticket)MainListBox.SelectedItem; // need cast?
        allTickets.Remove(ticketToRemove);
        // save...
    }
