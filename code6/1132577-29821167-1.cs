     public class Bar
            {
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public virtual int Id { get; set; }
    
    
                private ICollection<Foo> _foo1;
                [InverseProperty("Bars")]
                public virtual ICollection<Foo> Foos1
                {
                    get { return _foo1?? (_foo1= new Collection<Foo>()); }
                    set { _foo1= value; }
                }
    
                   private ICollection<Foo> _foo2;
                    [InverseProperty("Bars2")]
                    public virtual ICollection<Foo> Foos2
                    {
                        get { return _foo2?? (_foo2= new Collection<Foo>()); }
                        set { _foo2= value; }
                    }
    
    
                }
