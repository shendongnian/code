    public event EventHandler<ModelAddedEventArgs<Contact>> ContactAdded;
		public void AddModel(Contact model)
		{
            // first add your contact then:
			if (ActivityGroupAdded != null)
                ActivityGroupAdded(this, new ModelAddedEventArgs<Contact>(model));
		}
