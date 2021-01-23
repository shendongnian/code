    using (ConEntities context = new ConEntities())
        {
        // ContactID is an output parameter.
        ObjectParameter ContactID = new ObjectParameter("ContactID ", typeof(int));
        SqlParameter Name = new SqlParameter("@Name", "hello sir");
        context.GetDepartmentName(ContactID, Name);
        //Console.WriteLine(ContactID.Value); 
        }
