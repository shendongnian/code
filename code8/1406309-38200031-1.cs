         //Method in controller
         public async Task<IHttpActionResult> Save(BacklogModifyVM item)
         {
            //Validate VM
            var validator = new BacklogModifyVMValidator();
            var result = validator.Validate(item);
            if (!result.IsValid)
            {
                return InvalidDataResponse(result.Errors);
            }
          }
          //entity class
          public class BacklogModifyVM
          {
             public decimal BacklogId { get; set; }
             public string BacklogTitle { get; set; }      
             public decimal BackLogStatusId { get; set; }
             public string Owners { get; set; }        
             public decimal ProjectId { get; set; }
             public string Description { get; set; }
             public decimal? EpicId { get; set; }       
          }
          //validator class
          public class BacklogModifyVMValidator : AbstractValidator<BacklogModifyVM>
          {
              public BacklogModifyVMValidator()
              {
                RuleFor(x => x.BacklogId).GreaterThanOrEqualTo(-1).NotEqual(0);
                RuleFor(x => x.BacklogTitle).NotEmpty();
                RuleFor(x => x.BackLogStatusId).GreaterThan(0);
                RuleFor(x => x.ProjectId).GreaterThan(0);
                RuleFor(x => x.Owners).Matches(@"((\d+)((\.\d{1,2})?))$");
               }
          }
