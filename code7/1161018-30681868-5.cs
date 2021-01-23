    void ControlReceivedFocus(object sender, EventArgs e)
    {
        if (!((sender as Control).ClientRectangle
            .Contains(PointToClient(MousePosition))))
        {
            goToActive(sender);
        }
    }
