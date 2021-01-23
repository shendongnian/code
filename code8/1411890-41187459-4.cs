    using (var context = new EmailDbContext())
    {
        IEmailRepository repository = new EmailRepository(context);
        
        var email = new Email();
                    
        repository.Add(email);
    
        context.SaveChanges();
    
        var emailFoundById = repository.GetById(email.Id);
    }
