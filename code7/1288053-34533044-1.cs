    public class Main
    {
        List<Conflict> conflicts;
        public void AddFormConflict(List<Form> locals, List<Form> remotes)
        {
            if (conflicts.Any(c => c.localForms.Any(lf => locals.Any(lc => lf.Id == lc.Id))))
            {
                //duplicate found for localForms
            }
            //similarly check for remoteForms
        }
    }
