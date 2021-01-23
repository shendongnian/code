        using(SearchProduct sp=new SearchProduct(this))
        {
            sp.ShowDialog(this);
        }
        //In constructor of SearchProduct
        BillingForm MyParent; 
        public SearchProduct(BillingForm parent)
        {
         this.MyParent=parent;
        }
       private void dataGridView1_KeyDown(object sender,KeyEventArgs e)
       {
       if(e.KeyCode==Keys.Enter)
        {
        BillingForm bf=(BillingForm)this.MyParent;   //Error appear here 
        bf.updatedText("Hello World");
        this.close();
        }
       }
