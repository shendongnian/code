        public void Test1()
        {
            var app = new Applicant();
            CreatePropertyValue(app, new Phone(), a => a.PhoneNumbers, (a, v) => a.PhoneNumbers = v);
            CreatePropertyValue(app, new Employer(), a => a.Employers, (a, v) => a.Employers = v);
        }
        public static long CreatePropertyValue<T>(Applicant applicant, T data, Func<Applicant, List<T>> getter, Action<Applicant, List<T>> setter)
            where T : BaseApplicationData
        {
            long newId = 0;
            var list = getter(applicant); //get list
            if (list == null) //check it
            {
                list = new List<T>();
                data.Id = newId;
                list.Add(data); //add new data
                setter(applicant, list); //set new list
            }
            return newId;
        }
