    public class ConditionCreator 
    {
        public ConditionCreator() { ... }
        public SubConditionCreator Add() { ...; return new SubConditionCreator(this); }
        internal ConditionCreator OnAdd() { ...; return this; };
        internal ConditionCreator OnOr() { ...; return this; };
    }
    
    public class SubConditionCreator
    {
        private ConditionCreator _creator;
        internal SubConditionCreator(ConditionCreator c) { _creator = c; }
        public ConditionCreator And() { return _creator.OnAdd(); }
        public ConditionCreator Or() { return _creator.OnOr(); }
    }
