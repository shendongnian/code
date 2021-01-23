       protected void dsDocumentSourceRules_Inserting(object sender,
         ObjectDataSourceMethodEventArgs e) {
             ReplaceRule rule = (ReplaceRule)e.InputParameters["obj"];
            DocumentRuleViewModel.Insert(rule, Int32.Parse(DocumentTypeIDTextBox.Value.ToString()));
             e.Cancel = true; } 
...  
    [DataObjectMethod(DataObjectMethodType.Insert, true)] public static
        void Insert(ReplaceRule obj, Int32 DocumentId) {
             obj.ID = data.Count;
             obj.TypeID = DocumentId;
             data.Add(obj); }
 
