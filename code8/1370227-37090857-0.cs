    public class Condition 
    {
        public int Id {get;set; }
        public int? ParentConditionId {get;set;}
        public virtual Condition ParentCondition {get;set;}
        public int? ParentActionId {get;set; }
        public virtual Action ParentAction {get;set;}
        public string Whatever {get;set;}
    }
    
    public class Action 
    {
        public int Id {get;set; }
        public int ParentConditionId {get;set;}
        public virtual Condition ParentCondition {get;set;}
        public int? ParentActionId {get;set;}
        public virtual Action ParentAction {get;set;}
        public string Whatever {get;set;}
    }
