    @helper CustomRenderingOfColumn(Customer customer)
    {
        if (customer.LastName == 'Me')
        {
        <span class="label label-success">Active</span>
        }
        else
        {
        <span class="label label-important">Banned</span>
        }
    }
