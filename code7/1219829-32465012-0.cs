    private void label1_TextChanged( object sender, EventArgs e )
        {
            if ( this._calories < 0 )
            {
                this.lb_Main.BackColor = Color.Red;
            }
            else
            {
                this.lb_Main.BackColor = Color.Green;
            }
        }
