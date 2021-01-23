     public class Foo
            {
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public virtual int Id { get; set; }
        
        
                private ICollection<Bar> _bar;
                public virtual ICollection<Bar> Bars
                {
                    get { return _bar?? (_bar= new Collection<Bar>()); }
                    set { _bar= value; }
                }
    
                private ICollection<Bar> _bar2;
                public virtual ICollection<Bar> Bars2
                {
                    get { return _bar2?? (_bar2= new Collection<Bar>()); }
                    set { _bar2= value; }
                }
            }
