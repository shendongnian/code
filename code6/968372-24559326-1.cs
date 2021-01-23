    using (var context = new MyContext())
            {
                Console.WriteLine("*Change State Child");
                context.Entry(c1).State = EntityState.Added; // Conflicting changes to the role 'Child_TheOnlyParent_Target' of the relationship 'Child_TheOnlyParent' have been detected.
                Console.WriteLine("*Change State Child->Parent Navigability Property");
                context.Entry(c1.TheOnlyParent).State = EntityState.Unchanged; // We do not want to create but reuse
                Console.WriteLine("*Save Changes");
                context.SaveChanges();
            }
