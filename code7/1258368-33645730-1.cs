        public void Save(string Name, string Num)
        {
	          using(var context =  new Phone_BookEntities1())
	          {
		           var existingContacts = Context.Cantacts.Where( c=>c.Cantact1 == Name); //there can be many contacts with the same name. Use FirstOrDefault and also improve the filtering   criteria
		           if(existingContacts.Any())
		           {
			            foreach(var contact in existingContacts)
			            {	
				             contact.Number = Num;
			            }
		           }else
		           {	
			              var Ref_Cantact =  new Cantact(){Cantact1 = Name, Number = Num};
			             context.Cantacts.Add(Ref_Cantact);
		           }
		           Contex.SaveChanges();
	         }
        }
