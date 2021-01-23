    void Observe(Customer c)
    {
        c.PropertyChanged += (s, e) => 
        {
            if (e.PropertyName == Customer.CustomerIdPropertyName)
            {
                MessageBox.Show("New id " + Customer.CustomerId);
            }
        }
    }
