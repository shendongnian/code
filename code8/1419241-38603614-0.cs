    gridControlDocument.DataSource = 
              new BindingList<Document>(_documentRepository
              .Get()
              .Where(i => EntityFunctions.TruncateTime(i.SubmitDateTime)==subDateTime)
              .ToList()) { AllowNew = true };
