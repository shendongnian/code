    public class SomethingImportant {
        public int Id {get;set;}
        public string Name {get;set;}
    
        public int UserTypeId {get;set;}
        [Display(Name="User Type")]//here
        public virtual UserType UserType {get;set;}
    
        public int ReferenceTypeId {get;set;}
        [Display(Name="Reference Type")]//and here
        public virtual ReferenceType ReferenceType {get;set;}
    }
