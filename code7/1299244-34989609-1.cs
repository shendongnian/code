     public class SmartFormStrategy : FormStrategy
            {
                public override void OnAfterSubmit(FormData formData, FormSubmittedData submittedFormData, string formXml,
                    CmsEventArgs eventArgs)
                {
                    var formFieldDataItem = submittedFormData.DataItems.ToList().FirstOrDefault(x => x.FieldName == "EktFormId");
    
    //act upon the form submit results
                  }
        }
