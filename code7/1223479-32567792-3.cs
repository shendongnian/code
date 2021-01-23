    void msg_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "DLMessage")
            MessageBox.Show("at last changed!");
    }
