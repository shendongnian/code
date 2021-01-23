        public class Person : IComparable<Person>, IComparable, ICloneable
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
            public double Weight { get; set; }
            public Address Address { get; set; }
    
            public int Age
            {
                get
                {
                    TimeSpan ts = DateTime.Now.Subtract( BirthDate );
                    return new DateTime( ts.Ticks ).Year - 1;
                }
            }
    
            public string FullName
            {
                get
                {
                    return string.Format( "{0} {1}", LastName, Name ).Trim();
                }
            }
    
    
    
            public override string ToString()
            {
                return string.Format( "[{0}] - {1}, born at {2:dd/MM/yyyy} ({3} years old), {4:#,##0.00} kg", ID, FullName, BirthDate, Age, Weight );
            }
    
            public override bool Equals( object obj )
            {
                if ( ( obj == null ) || ( !( obj is Person ) ) )
                    return false;
    
                Person other = (Person)obj;
    
                return ( this.ID == other.ID ) &&
                    ( this.Name == other.Name ) &&
                    ( this.LastName == other.LastName ) &&
                    ( this.BirthDate == other.BirthDate ) &&
                    ( this.Weight == other.Weight );
    
            }
    
            public override int GetHashCode()
            {
                return ID.GetHashCode() * 2 +
                    Name.GetHashCode() * 3 +
                    LastName.GetHashCode() * 4;
            }
    
    
    
            #region IComparable<Person> Members
    
            public int CompareTo( Person other )
            {
                if ( other == null )
                    return -1;
    
                return this.FullName.CompareTo( other.FullName );
            }
    
            #endregion
    
            #region IComparable Members
    
            public virtual int CompareTo( object obj )
            {
                if ( ( obj == null ) || ( !( obj is Person ) ) )
                    return -1;
    
                Person other = (Person)obj;
    
                return CompareTo( other );
            }
    
            #endregion
    
            #region ICloneable Members
    
            public virtual object Clone()
            {
                return new Person() { ID = this.ID, Name = this.Name, LastName = this.LastName, BirthDate = this.BirthDate, Weight = this.Weight };
            }
    
            #endregion
        }
