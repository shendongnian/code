    public static Result SaveCutomer(Customer customer)
    {
        using (AshdorEntities context = new AshdorEntities())
        {
            try
            {
    			//assumption is that its always a disconnected entity if not you will need to check
    			context.Customer.Attach(customer);
    		
    			//this seems wrong as well
                Contact con = null;
    			
    			customer.enterDate = DateTime.Now;
    			
    			//this seems wrong as well
    			customer.Contact.dateEnter = customer.enterDate;
    			
    			//this seems wrong as well
    			con = context.Contact.Add(customer.Contact);
    			
    			customer.Contact = null;
    			//this seems wrong as well
    			customer.customerId = con.contactId;
    			
                if (customer.customerId == 0)//new customer
                {
    			    context.Entry(customer).State = EntityState.Added 
                }
                else //existing 
    			{
    				context.Entry(customer).State = EntityState.Modified; 
    			}
                context.SaveChanges();
            }
            catch 
            {
                return new Result() { status = false, massege = MassegesResult.ADDING_FAILED };
            }
    
            return new Result() { status = true, massege = MassegesResult.ADDING_SUCCESSFUL };
        }
    }
