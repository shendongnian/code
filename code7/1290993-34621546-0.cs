     protected void Page_Load(object sender, EventArgs e)
            {
                    test_person = new Person("Neil");
                    person2 = new Person("2");
                    person3 = new Person("3");
                    test_person.OnFullyFed += Test_person_OnFullyFed;
                    person2.OnFullyFed += Test_person_OnFullyFed;
                    person3.OnFullyFed += Test_person_OnFullyFed;
                
            }
