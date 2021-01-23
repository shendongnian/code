    public class TemplateService : ITemplateService
    {
    
        ITemplateRepository _templateRepo; 
        IUProduceRepository _produceRepo
    
        public TemplateService(ITemplateRepository templateRepo, IUProduceRepository produceRepo)
        {
            _templateRepo = templateRepo;
            _produceRepo = produceRepo;
        } 
    
    
        public TemplateResponse UpdateTemplate(Template template)
        {
            try
            {
                var result = _templateRepo.Update(template);
                return result;
            }
            catch(Exception ex)
            {
                // If something went wrong. Always return null. (or whatever)
                return null;
            }
        }
    }
    [Test]
    public void TemplateService_UpdateTemplate_ShouldReturnNullOnError()
    {
        Template template = new Template() // note that I changed the variable name.
        {
            TemplateId = 123,
        };
        // Arrange.
        TemplateUpdateRequest request = new TemplateUpdateRequest()
        {
            ExistingTemplate = template 
        };
        var templateRepo = new Mock<ITemplateRepository>();
        var uproduceRepo = new Mock<IUProduceRepository>();
         // Mock exception
         templateRepo.Setup(p => p.UpdateTemplate(request)).Throw(new ArgumentException("Something went wrong");
         // Act.
         TemplateService svc = new TemplateService(templateRepo, uproduceRepo);
         TemplateResponse response = svc.UpdateTemplate(request);
         // Assert.
         // Make sure that the exception is handled and null is returned instead.
         Assert.IsNull(response); 
    }
