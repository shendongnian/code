    public void SomeMethod(){                
                var xx = this.Relation(new TableMapper<Student>(), dummy, new TableMapper<Department>(), dummy);
            }
    
            string dummy(string xx)
            {
                return xx + "Hello";
            }
