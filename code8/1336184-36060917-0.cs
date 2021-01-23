        public void GetCompleteList(List<Person> personsList)
        {
            personsList.Add(this);
            if (person != null)
            {
                person.GetCompleteList(personsList);
            }
        }
