    Session SaveSession(Session input) {
        using(var context = new DbContext()){
            if(input.ID != 0) {
                // Entity exists, modify the original
                var mySession = context.Sessions.Find(input.ID);
                mySession.Name = input.Name;
                mySession.Color = input.Color;
                // Etc.
                // Make sure that foreign keys are pulled from current context and not duplicated
                mySession.Patient = context.Patients.Find(input.Patient.ID);
            
                context.Entry(mySession).EntityState = EntityState.Modified;
            } else {
                // Entity does not exist, add fresh
                // Make sure that foreign keys are pulled from current context and not duplicated
                input.Patient = context.Patients.Find(input.Patient.ID);
                context.Add(input);
            }
            context.SaveChanges();
            return input;
        }
    }
