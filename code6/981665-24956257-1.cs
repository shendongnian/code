    private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
    {
        Foo item = ( listBox1.SelectedItem as Foo );
        if( item != null )
        {
            // use item.Id here
        }
    }
