      class CodeConfiguration : EntityTypeConfiguration<Code>
        {
          public CodeConfiguration()
         {
          
          //other codes      
          
            HasOptional(c => c.HelperCode)
                .WithRequired(hc => hc.Code).HasForginKey(x=>x.HelperCodeId);
          }
        }
