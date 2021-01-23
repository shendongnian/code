       private string _Title;
       [RuleRequiredField("RuleID_TitleIsRequired", DefaultContexts.Save, "A title must be specified.")]
       public string Title {
          get { return _Title; }
          set { SetPropertyValue("Title", ref _Title, value); }
       }
