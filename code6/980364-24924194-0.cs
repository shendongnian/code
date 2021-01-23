    public class PhoneData
     {
       public int ID {get;set;}
       public string SomeProperty {get;set;}
     }
    
    public class PhoneDataMap : EntityTypeConfiguration<PhoneData>
        {
            public PhoneDataMap()
            {
                ToTable("WhatEverYou_Want_to_call_this");
                HasKey(m => m.Id);
                Property(m => m.SomeProperty).HasColumnName("whatever").IsRequired();
                //etc.
            }
        }
