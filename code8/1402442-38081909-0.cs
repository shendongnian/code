    public class FieldGroupItemInstanceMap() 
    {
            public FieldGroupItemInstanceMap()
            {
                    Table("FieldGroupItemInstance");
    
                    HasManyToMany(x => x.ChildGroups)
                            .Table("FieldGroupItemInstance_QuestionnaireFieldGroupInstance")
                            .ParentKeyColumn("IdFieldGroupItemInstance")
                            .ChildKeyColumn("IdQuestionnaireFieldGroupInstance")
                            .Cascade.None();
            }
    }
    
    public class QuestionnaireFieldGroupInstanceMap() 
    {
            public QuestionnaireFieldGroupInstanceMap()
            {
                    Table("QuestionnaireFieldGroupInstance");
    
                    HasManyToMany(x => x.FieldGroupItems)
                            .Table("FieldGroupItemInstance_QuestionnaireFieldGroupInstance")
                            .ParentKeyColumn("IdQuestionnaireFieldGroupInstance")
                            .ChildKeyColumn("IdFieldGroupItemInstance")
                            .Cascade.None();
            }
    }       
